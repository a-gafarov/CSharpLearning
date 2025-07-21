using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class RemoteCourse : Course
    {
        public string Url { get; set; }

        public RemoteCourse(string title, int length, string url)
            : base(title, length)
        {
            Url = url;
        }

        public void Connect()
        {
            Console.WriteLine($"Open Connection to {Url}");
        }

        public /* sealed */ override /*new*/ void Show()
        {
            base.Show(); // вызов метода родителя
            Console.WriteLine($"Remote course: {Title} : {Length} Connect to: {Url}");
            
        }
    }
}
