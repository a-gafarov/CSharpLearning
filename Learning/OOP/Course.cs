using System.Net.Http.Headers;

namespace OOP
{
    public /* sealed */  partial class Course
    {
        //public readonly string Title;// = "Новый курс";
        //private string title;
        /*public string Title
        {
            get {  return title; }   
            private set { title = value; }
        }*/
        /*public string Title
        {
            get => title;
            private set  => title = value;
        }*/

        // required - требует инициализации в блоке инициализации { Title = ".."}
        // даже если конструктор инициализирует
        public /*required*/ string Title { get; init; }// = "Новый курс";

        private int length;// = 8;

        public int Length // свойство - property
        {
            get { return length; }
            set // init
            {
                if (value >= MIN_LENGTH && value <= MAX_LENGTH)
                    this.length = value;
                else
                    throw new ArgumentException($"Course Length out of [{MIN_LENGTH}..{MAX_LENGTH}]");
            }        
        }

        /*private string description;
        public string Description
        {
            get { return description;  }
            set { description = value; }   
        }*/

        // auto property
        public string? Description { get; set; }


        //private string description;
        //public string Description => description; // readonly like public string Description { get; }

        public const int MIN_LENGTH = 8;
        public const int MAX_LENGTH = 48;

        private static int counter = 0;
        public static void ShowCoursesCounter()
        {
            Console.WriteLine($"Total Courses: {counter}");
        }

        // вызывается автоматически CLR при первом обращении к классу
        // используется для сложной инициализации статических полей
        static Course()
        {
            // counter = 0;
        }

        public Course() : this("Новый курс") // вызов другого конструктора этого же класса
        { 
        
        }
        public Course(string Title, int Length = 8  )
        {
            this.Title = Title;
            this.Length = Length;
            
            //Course.counter++;
            counter++;
        }

        // Без модификатора доступа (private), не должен возращать значение (void)
        partial void Validate();
        public virtual void Show()
        {
            Validate(); // компилятор пропустит вызов метода, если он остался не реализован
            // this - ссылка на объект, для которого вызван этот метод
            Console.WriteLine($"{this.Title} : {Length}"); 
        }

        // обычно нет необходимости добавлять деструктор
        ~Course() 
        {
            Console.WriteLine("~Course()");
        }
    }
}
