/*Лабораторная 1.4

- Используя проект SocketServer и SocketClientMT для того чтобы добиться ошибок
клиента (не все запросы клиентов обрабатываются однопоточным сервером)
- Создать новый проект SocketServerMT (на основе SocketServer),
превратив сервер в многопоточный, используя Task
- Добиться, чтобы все запросы многопоточного клиента успешно обработались
*/

using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;

const int MAX_CONNECTION_IN_QUEUE = 10; // 10

const int CLIENTS = 10;
ThreadPool.SetMinThreads(CLIENTS, CLIENTS);
ThreadPool.SetMaxThreads(CLIENTS, CLIENTS);

IPEndPoint ipPoint = new(IPAddress.Any, 1111);
using Socket socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
socket.Bind(ipPoint);
socket.Listen(MAX_CONNECTION_IN_QUEUE);
int req = 0;
object lock_req = new();

//ConcurrentQueue<Task> taskQueue = new();

while (req < 1000)
{
	Socket client = socket.Accept();

	new Task(input =>
	{
		using var myClient = input as Socket;
		if (myClient == null)
		{
			Console.Write("Socket is null =(");
			return;
		}
		StringBuilder sb = new();
		sb.AppendLine($"Remote client {myClient.RemoteEndPoint} proccessed by {Thread.CurrentThread.ManagedThreadId}");
		using var stream = new NetworkStream(myClient);
		using var r = new StreamReader(stream, Encoding.UTF8);
		using var w = new StreamWriter(stream, Encoding.UTF8);
		string result = r.ReadLine() ?? "-empty line-";
		lock (lock_req)
			sb.AppendLine($"Received: {result}, Requests: {++req}");
		Console.WriteLine(sb.ToString());
		Thread.Sleep(100);

		w.WriteLine(result.ToUpper());
		w.Flush();
	}, client).Start();

	//taskQueue.Enqueue(task);
}
