/*Лабораторная 1.5

- В проекте BinaryBalancedTree распараллелить метод подсчета веса дерева используя асинхронные методы.
- Замерить время выполнения однозадачного и многозадачного метода, проверить результат
- Добиться ускорения в многозадачном варианте на многоядерном процессоре (использовать Build Release)
*/

using System.Diagnostics;
using System.Security.Cryptography;

namespace Lab1._5
{
	public class TreeNode
	{

		public TreeNode? Left { get; set; }
		public TreeNode? Right { get; set; }

		public int Weight { get; set; }

	}


	internal class Program
	{
		static Random rnd = new Random();
		static long total;

		public static void CreateRandomTree(TreeNode node, int level)
		{
			node.Left = new TreeNode();
			node.Right = new TreeNode();
			node.Weight = rnd.Next(100);
			total += node.Weight;
			level--;
			if (level == 0)
			{
				node.Left.Weight = rnd.Next(100);
				node.Right.Weight = rnd.Next(100);
				total += node.Left.Weight;
				total += node.Right.Weight;
				return;
			}
			CreateRandomTree(node.Left, level);
			CreateRandomTree(node.Right, level);
		}


		public static long weightTree(TreeNode? root)
		{
			if (root == null) return 0;
			return (long)root.Weight + weightTree(root.Left) + weightTree(root.Right);
		}

		async public static Task<long> weightTreeAsync(TreeNode? root, int depth)
		{
			if (root == null) return 0;

			if (depth <= 0) return weightTree(root);

			Task<long> taskLeft = Task.Run(() => weightTreeAsync(root.Left, depth - 1));
			Task<long> taskRight = Task.Run(() => weightTreeAsync(root.Right, depth - 1));

			return (long)root.Weight + await taskLeft + await taskRight;
		}

		static async Task Main(string[] args)
		{
			int treeLevel = 28; // 2^(n+1)-1

			Console.WriteLine($"Starting tree creation with depth {treeLevel}...");
			TreeNode root = new TreeNode();
			CreateRandomTree(root, treeLevel);
			Console.WriteLine($"Tree created with total weight: {total}");


			Stopwatch t1 = new();
			t1.Start();
			long r1 = weightTree(root);
			t1.Stop();
			Console.WriteLine($"Single weight: {r1}, Time: {t1.ElapsedMilliseconds}");


			for (int i = 1; i <= 20; i++)
			{
				Stopwatch t2 = new();
				t2.Start();
				long r2 = await weightTreeAsync(root, i);
				t2.Stop();
				Console.WriteLine($"Single weight async: {r2}, Async depth: {i}, Tasks: {Math.Pow(2, i)}, Time: {t2.ElapsedMilliseconds}");
			}
		}
	}
}