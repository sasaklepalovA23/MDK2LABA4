
using System;
using System.Collections.Generic; 
using System.Linq; 

namespace MDK2LABA4
{
  

    #region Вариант 1
   
    class Phone
    {
        public string Number { get; set; }
        public string Model { get; set; }
        public double Weight { get; set; }

        public Phone(string number, string model, double weight)
        {
            Number = number;
            Model = model;
            Weight = weight;
        }

        public void ReceiveCall(string name)
        {
            Console.WriteLine($"Телефон {Model} ({Number}): Звонит {name}");
        }

        public string GetNumber()
        {
            return Number;
        }

        public void SendMessage(params string[] numbers)
        {
            Console.WriteLine($"Телефон {Model} ({Number}): Отправка сообщения на следующие номера:");
            foreach (string num in numbers)
            {
                Console.WriteLine($"- {num}");
            }
        }
    }
    #endregion

    #region Вариант 2: Класс Person
    
    class Person
    {
        public string FullName { get; set; }
        public int Age { get; set; }

        public Person()
        {
            FullName = "Неизвестный";
            Age = 0;
        }

        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

       
        public void Move()
        {
            Console.WriteLine($"{FullName} (возраст {Age}) идет.");
        }

       
        public void Talk()
        {
            Console.WriteLine($"{FullName} (возраст {Age}) говорит: 'Привет!'");
        }
    }
    #endregion

    #region Вариант 3: Класс Матрица
   
    class Matrix
    {
        private double[,] data;
        public int Rows { get; private set; } 
        public int Columns { get; private set; } 

        public Matrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
            {
                throw new ArgumentException("Количество строк и столбцов должно быть положительным.");
            }
            Rows = rows;
            Columns = columns;
            data = new double[rows, columns];
        }
        
        public double GetValue(int row, int col)
        {
            if (row < 0 || row >= Rows || col < 0 || col >= Columns)
                throw new IndexOutOfRangeException("Индексы выходят за пределы матрицы.");
            return data[row, col];
        }

        public void SetValue(int row, int col, double value)
        {
            if (row < 0 || row >= Rows || col < 0 || col >= Columns)
                throw new IndexOutOfRangeException("Индексы выходят за пределы матрицы.");
            data[row, col] = value;
        }

        public void FillRandom(int minValue = 1, int maxValue = 10)
        {
            Random rnd = new Random();
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    data[i, j] = rnd.Next(minValue, maxValue + 1); 
        }

        public void Print()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write($"{data[i, j]:F1}\t"); 
                }
                Console.WriteLine();
            }
        }

        public Matrix Add(Matrix other)
        {
            if (Rows != other.Rows || Columns != other.Columns)
            {
                throw new ArgumentException("Матрицы должны быть одного размера для сложения.");
            }
            Matrix result = new Matrix(Rows, Columns);
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    result.data[i, j] = this.data[i, j] + other.data[i, j];
            return result;
        }

        public Matrix Multiply(double scalar)
        {
            Matrix result = new Matrix(Rows, Columns);
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    result.data[i, j] = this.data[i, j] * scalar;
            return result;
        }

        public Matrix Multiply(Matrix other)
        {
            if (this.Columns != other.Rows)
            {
                throw new ArgumentException("Число столбцов первой матрицы должно быть равно числу строк второй матрицы для умножения.");
            }
            Matrix result = new Matrix(this.Rows, other.Columns);
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < other.Columns; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < this.Columns; k++)
                    {
                        sum += this.data[i, k] * other.data[k, j];
                    }
                    result.data[i, j] = sum;
                }
            }
            return result;
        }
    }
    #endregion

    #region Вариант 4: Класс Reader
    
    class Reader
    {
        public string FullName { get; set; }
        public int TicketNumber { get; set; }
        public string Faculty { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }

        public Reader(string fullName, int ticketNumber, string faculty, DateTime dob, string phone)
        {
            FullName = fullName;
            TicketNumber = ticketNumber;
            Faculty = faculty;
            DateOfBirth = dob;
            PhoneNumber = phone;
        }

        
        public void TakeBook(string bookTitle)
        {
            Console.WriteLine($"{FullName} (билет №{TicketNumber}) взял книгу: '{bookTitle}'");
        }

        public void ReturnBook(string bookTitle)
        {
            Console.WriteLine($"{FullName} (билет №{TicketNumber}) вернул книгу: '{bookTitle}'");
        }

        public void PrintInfo()
        {
            Console.WriteLine($"  ФИО: {FullName}, Билет: {TicketNumber}, Факультет: {Faculty}, Дата рождения: {DateOfBirth.ToShortDateString()}, Телефон: {PhoneNumber}");
        }
    }
    #endregion

    #region Вариант 5: Класс Tiles
   
    class Tiles
    {
        public string Brand { get; set; }
        public int SizeHeight { get; set; } 
        public int SizeWidth { get; set; } 
        public decimal Price { get; set; } 

      
        public Tiles(string brand, int sizeHeight, int sizeWidth, decimal price)
        {
            Brand = brand;
            SizeHeight = sizeHeight;
            SizeWidth = sizeWidth;
            Price = price;
        }

        public void GetData()
        {
            Console.WriteLine($"Бренд: {Brand}, Размер: {SizeHeight}x{SizeWidth} см, Цена: {Price:C}");
        }
    }
    #endregion

    #region Вариант 6: Класс Children
    
    class Children
    {
        private string firstName;
        private string lastName;
        private int age;

        public void InputData()
        {
            Console.Write("Введите имя ребенка: ");
            firstName = Console.ReadLine();
            Console.Write("Введите фамилию ребенка: ");
            lastName = Console.ReadLine();
            Console.Write("Введите возраст ребенка: ");
            if (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Некорректный ввод возраста. Установлен возраст 0.");
                age = 0;
            }
        }

        public void DisplayData()
        {
            Console.WriteLine($"Ребенок: {lastName} {firstName}, Возраст: {age} лет.");
        }
    }
    #endregion

    #region Вариант 7: Класс Куб
   
    class Cube
    {
        private double side;

        public Cube(double sideLength)
        {
            if (sideLength <= 0)
            {
                throw new ArgumentException("Длина стороны куба должна быть положительной.");
            }
            side = sideLength;
        }

        
        public double SideLength => side; 
        public double FaceArea => side * side; 
        public double SurfaceArea => 6 * side * side; 
        public double Volume => Math.Pow(side, 3);
        
        public void PrintState()
        {
            Console.WriteLine($"  Сторона куба: {SideLength:F2}");
            Console.WriteLine($"  Площадь одной грани: {FaceArea:F2}");
            Console.WriteLine($"  Площадь всей поверхности: {SurfaceArea:F2}");
            Console.WriteLine($"  Объем куба: {Volume:F2}");
        }
    }
    #endregion

    #region Вариант 8: Десятичный счетчик
    
    class DecimalCounter
    {
        private int current; 
        private int min, max; 

        public DecimalCounter(int start = 0, int min = 0, int max = 10)
        {
            this.min = min;
            this.max = max;
          
            this.current = (start >= min && start <= max) ? start : min;
            Console.WriteLine($"Счетчик инициализирован в диапазоне [{min}, {max}] со значением {current}");
        }

        public void Increment()
        {
            if (current < max)
            {
                current++;
                Console.WriteLine($"Значение увеличено: {current}");
            }
            else
            {
                Console.WriteLine($"Значение не может быть увеличено, достигнут максимум ({max}). Текущее: {current}");
            }
        }

        public void Decrement()
        {
            if (current > min)
            {
                current--;
                Console.WriteLine($"Значение уменьшено: {current}");
            }
            else
            {
                Console.WriteLine($"Значение не может быть уменьшено, достигнут минимум ({min}). Текущее: {current}");
            }
        }

        public int State => current;
    }
    #endregion

    #region Вариант 9: Время
   
    class TimeClass
    {
        private int hours, minutes, seconds;

        public TimeClass(int h = 0, int m = 0, int s = 0)
        {
            SetTime(h, m, s); 
        }

        public void SetTime(int h, int m, int s)
        {
            if (h < 0 || h > 23) throw new ArgumentOutOfRangeException(nameof(h), $"Часы ({h}) должны быть от 0 до 23.");
            if (m < 0 || m > 59) throw new ArgumentOutOfRangeException(nameof(m), $"Минуты ({m}) должны быть от 0 до 59.");
            if (s < 0 || s > 59) throw new ArgumentOutOfRangeException(nameof(s), $"Секунды ({s}) должны быть от 0 до 59.");

            hours = h; minutes = m; seconds = s;
            Console.WriteLine($"Время установлено: {ToString()}");
        }

        public void AddHours(int h)
        {
            hours = (hours + h) % 24;
            if (hours < 0) hours += 24; 
            Console.WriteLine($"Добавлено {h} часов. Новое время: {ToString()}");
        }

        
        public void AddMinutes(int m)
        {
            minutes += m;
            AddHours(minutes / 60); 
            minutes %= 60;
            if (minutes < 0) { minutes += 60; AddHours(-1); } 
            Console.WriteLine($"Добавлено {m} минут. Новое время: {ToString()}");
        }

        public void AddSeconds(int s)
        {
            seconds += s;
            AddMinutes(seconds / 60); 
            seconds %= 60;
            if (seconds < 0) { seconds += 60; AddMinutes(-1); } 
            Console.WriteLine($"Добавлено {s} секунд. Новое время: {ToString()}");
        }

        public override string ToString() => $"{hours:D2}:{minutes:D2}:{seconds:D2}";
    }
    #endregion

    #region Вариант 10: Треугольник
 
    class Triangle
    {
        public double X1 { get; private set; }
        public double Y1 { get; private set; }
        public double X2 { get; private set; }
        public double Y2 { get; private set; }
        public double X3 { get; private set; }
        public double Y3 { get; private set; }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            
            if (Math.Abs(x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) < 1e-9)
            {
                throw new ArgumentException("Точки образуют вырожденный треугольник (лежат на одной прямой).");
            }

            X1 = x1; Y1 = y1;
            X2 = x2; Y2 = y2;
            X3 = x3; Y3 = y3;
        }

        private double CalculateSideLength(double px1, double py1, double px2, double py2)
        {
            return Math.Sqrt(Math.Pow(px2 - px1, 2) + Math.Pow(py2 - py1, 2));
        }

       
        public double SideA => CalculateSideLength(X1, Y1, X2, Y2);
        public double SideB => CalculateSideLength(X2, Y2, X3, Y3);
        public double SideC => CalculateSideLength(X3, Y3, X1, Y1);

        public double Perimeter => SideA + SideB + SideC;

        public double Area
        {
            get
            {
                return Math.Abs((X1 * (Y2 - Y3) + X2 * (Y3 - Y1) + X3 * (Y1 - Y2)) / 2.0);
            }
        }

        public (double centerX, double centerY) Centroid
        {
            get
            {
                double cx = (X1 + X2 + X3) / 3.0;
                double cy = (Y1 + Y2 + Y3) / 3.0;
                return (cx, cy);
            }
        }

        public void PrintState()
        {
            Console.WriteLine($"  Вершины: ({X1:F1},{Y1:F1}), ({X2:F1},{Y2:F1}), ({X3:F1},{Y3:F1})");
            Console.WriteLine($"  Длины сторон: A={SideA:F2}, B={SideB:F2}, C={SideC:F2}");
            Console.WriteLine($"  Периметр: {Perimeter:F2}");
            Console.WriteLine($"  Площадь: {Area:F2}");
            Console.WriteLine($"  Точка пересечения медиан (центроид): X={Centroid.centerX:F2}, Y={Centroid.centerY:F2}");
        }
    }
    #endregion

    #region Вариант 11: Класс Student
   
    class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string GroupNumber { get; set; } 
        public string Faculty { get; set; }
        public int Course { get; set; }
        public string PhoneNumber { get; set; }

        public Student(string lastName, string firstName, string middleName, string groupNumber, string faculty, int course, string phoneNumber)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            GroupNumber = groupNumber;
            Faculty = faculty;
            Course = course;
            PhoneNumber = phoneNumber;
        }

        public void PrintStudentInfo()
        {
            Console.WriteLine($"  ФИО: {LastName} {FirstName} {MiddleName}");
            Console.WriteLine($"  Группа: {GroupNumber}, Факультет: {Faculty}, Курс: {Course}");
            Console.WriteLine($"  Номер телефона: {PhoneNumber}");
        }

        public static void DisplayStudentsInGroup(string targetGroupDirection, string targetGroupNumber, List<Student> students)
        {
            Console.WriteLine($"\n--- Студенты группы '{targetGroupDirection}-{targetGroupNumber}' ---");
            bool found = false;
            foreach (var student in students)
            {
               
                string[] groupParts = student.GroupNumber.Split('-');
                string studentGroupDirection = groupParts.Length > 0 ? groupParts[0] : "";
                string studentGroupNumber = groupParts.Length > 1 ? groupParts[1] : "";

                if (studentGroupDirection.Equals(targetGroupDirection, StringComparison.OrdinalIgnoreCase) &&
                    studentGroupNumber.Equals(targetGroupNumber, StringComparison.OrdinalIgnoreCase))
                {
                    student.PrintStudentInfo();
                    Console.WriteLine("--------------------");
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine($"  Студенты в группе '{targetGroupDirection}-{targetGroupNumber}' не найдены.");
            }
        }
    }
    #endregion

    #region Вариант 12: Компьютерное железо
   
    class Hardware
    {
        public string Type { get; set; } 
        public string Brand { get; set; }
        public string Model { get; set; }
        public int PowerScore { get; set; } 
        public decimal Price { get; set; }

        public Hardware(string type, string brand, string model, int powerScore, decimal price)
        {
            Type = type;
            Brand = brand;
            Model = model;
            PowerScore = powerScore;
            Price = price;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"  Тип: {Type,-15} | Бренд: {Brand,-10} | Модель: {Model,-20} | Мощность: {PowerScore,4} баллов | Цена: {Price,8:C}");
        }

        public static Hardware GetMostPowerfulComponent(List<Hardware> components)
        {
            return components?.OrderByDescending(c => c.PowerScore).FirstOrDefault();
        }

        public static Hardware GetCheapestComponent(List<Hardware> components)
        {
            return components?.OrderBy(c => c.Price).FirstOrDefault();
        }

        public static Dictionary<string, Hardware> GetMostPowerfulBuild(List<Hardware> allComponents)
        {
            Dictionary<string, Hardware> build = new Dictionary<string, Hardware>();
            var groupedByType = allComponents.GroupBy(c => c.Type);

            foreach (var group in groupedByType)
            {
                var mostPowerfulInType = group.OrderByDescending(c => c.PowerScore).FirstOrDefault();
                if (mostPowerfulInType != null)
                {
                    build[group.Key] = mostPowerfulInType;
                }
            }
            return build;
        }

        public static Dictionary<string, Hardware> GetCheapestBuild(List<Hardware> allComponents)
        {
            Dictionary<string, Hardware> build = new Dictionary<string, Hardware>();
            var groupedByType = allComponents.GroupBy(c => c.Type);

            foreach (var group in groupedByType)
            {
                var cheapestInType = group.OrderBy(c => c.Price).FirstOrDefault();
                if (cheapestInType != null)
                {
                    build[group.Key] = cheapestInType;
                }
            }
            return build;
        }
    }
    #endregion

    #region Вариант 13: Бегун
   
    class Runner
    {
        public string Name { get; set; }
        public double Height { get; set; } 
        public double Weight { get; set; }
        public int StepCount { get; set; } 
        public int HeartRate { get; set; } 
        public double CaloriesBurned { get; set; } 

        public Runner(string name, double height, double weight, int stepCount, int heartRate, double caloriesBurned)
        {
            Name = name;
            Height = height;
            Weight = weight;
            StepCount = stepCount;
            HeartRate = heartRate;
            CaloriesBurned = caloriesBurned;
        }

        public double CalculateDistance()
        {
            double stepLengthInMeters = (Height / 100.0) * 0.78;
            double distanceInMeters = stepLengthInMeters * StepCount;
            return distanceInMeters / 1000.0;
        }

        public void PrintRunnerInfo()
        {
            Console.WriteLine($"  Имя: {Name}");
            Console.WriteLine($"  Рост: {Height} см, Вес: {Weight} кг");
            Console.WriteLine($"  Количество шагов: {StepCount}");
            Console.WriteLine($"  Сердцебиение: {HeartRate} уд/мин");
            Console.WriteLine($"  Потрачено калорий: {CaloriesBurned} ккал");
        }
    }
    #endregion

    #region Вариант 14: Четырехугольная пирамида
    
    class SquarePyramid
    {
        public double BaseSide { get; private set; } 
        public double Height { get; private set; }   

        public SquarePyramid(double baseSide, double height)
        {
            if (baseSide <= 0 || height <= 0)
            {
                throw new ArgumentException("Сторона основания и высота пирамиды должны быть положительными.");
            }
            BaseSide = baseSide;
            Height = height;
        }

        public double BaseArea => BaseSide * BaseSide;
        public double SlantHeight 
        {
            get
            {
                return Math.Sqrt(Height * Height + Math.Pow(BaseSide / 2.0, 2));
            }
        }

        public double LateralSurfaceArea => 2 * BaseSide * SlantHeight;

        public double TotalSurfaceArea => BaseArea + LateralSurfaceArea; 

        public double Volume => (1.0 / 3.0) * BaseArea * Height; 

        public double CalculateTotalSurfaceArea() => TotalSurfaceArea;

        public double CalculateVolume() => Volume;

        public void PrintState()
        {
            Console.WriteLine($"  Параметры пирамиды:");
            Console.WriteLine($"    Сторона основания: {BaseSide:F2}");
            Console.WriteLine($"    Высота: {Height:F2}");
            Console.WriteLine($"  Расчетные значения:");
            Console.WriteLine($"    Площадь основания: {BaseArea:F2}");
            Console.WriteLine($"    Апофема: {SlantHeight:F2}");
            Console.WriteLine($"    Площадь боковой поверхности: {LateralSurfaceArea:F2}");
            Console.WriteLine($"    Площадь полной поверхности: {CalculateTotalSurfaceArea():F2}");
            Console.WriteLine($"    Объем: {CalculateVolume():F2}");
        }
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
          
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true) 
            {
                Console.WriteLine("Выберите вариант (1-14) для запуска или 0 для выхода:");
                Console.WriteLine(" ВАРИАНТ 1");
                Console.WriteLine(" ВАРИАНТ 2");
                Console.WriteLine(" ВАРИАНТ 3");
                Console.WriteLine(" ВАРИАНТ 4");
                Console.WriteLine(" ВАРИАНТ 5");
                Console.WriteLine(" ВАРИАНТ 6");
                Console.WriteLine(" ВАРИАНТ 7");
                Console.WriteLine(" ВАРИАНТ 8");
                Console.WriteLine(" ВАРИАНТ 9");
                Console.WriteLine(" ВАРИАНТ 10");
                Console.WriteLine(" ВАРИАНТ 11");
                Console.WriteLine(" ВАРИАНТ 12");
                Console.WriteLine(" ВАРИАНТ 13");
                Console.WriteLine(" ВАРИАНТ 14");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine(" 0. Выход из программы");
                Console.Write("\nВаш выбор: ");

                string choice = Console.ReadLine(); 
                Console.Clear(); 

                switch (choice)
                {
                    case "1": RunVariant1(); break;
                    case "2": RunVariant2(); break;
                    case "3": RunVariant3(); break;
                    case "4": RunVariant4(); break;
                    case "5": RunVariant5(); break;
                    case "6": RunVariant6(); break;
                    case "7": RunVariant7(); break;
                    case "8": RunVariant8(); break;
                    case "9": RunVariant9(); break;
                    case "10": RunVariant10(); break;
                    case "11": RunVariant11(); break;
                    case "12": RunVariant12(); break;
                    case "13": RunVariant13(); break;
                    case "14": RunVariant14(); break;
                    case "0":
                        Console.WriteLine("Программа завершена.");
                        return; 
                    default:
                        Console.WriteLine("Неверный ввод. Пожалуйста, выберите число от 0 до 14.");
                        Pause(); 
                        break;
                }
            }
        }

        static void Pause()
        {
            Console.WriteLine("\n[Нажмите ENTER, чтобы продолжить...]");
            Console.ReadLine(); 
        }

        static void RunVariant1()
        {
            Console.WriteLine("=== ВАРИАНТ 1 ===");
            Console.WriteLine("\nШаг 1: Создаем три экземпляра класса Phone ");
            Phone phone1 = new Phone("8-900-111-22-33", "iPhone 13", 174.5);
            Phone phone2 = new Phone("8-922-555-66-77", "Samsung Galaxy S21", 169.0);
            Phone phone3 = new Phone("8-911-444-33-22", "Xiaomi Mi 11", 196.0);
            Console.WriteLine("Три объекта Phone успешно созданы.");
            Pause();

            Console.WriteLine("\nШаг 2: телефон.");
            Console.WriteLine($"  Телефон 1: Номер: {phone1.Number}, Модель: {phone1.Model}, Вес: {phone1.Weight}г");
            Console.WriteLine($"  Телефон 2: Номер: {phone2.Number}, Модель: {phone2.Model}, Вес: {phone2.Weight}г");
            Console.WriteLine($"  Телефон 3: Номер: {phone3.Number}, Модель: {phone3.Model}, Вес: {phone3.Weight}г");
            Pause();
            Console.WriteLine("\nШаг 3:");
            phone1.ReceiveCall("Алексей");
            Console.WriteLine($"  Номер телефона 1: {phone1.GetNumber()}");
            Pause();

            phone2.ReceiveCall("Мария");
            Console.WriteLine($"  Номер телефона 2: {phone2.GetNumber()}");
            Pause();

            phone3.ReceiveCall("Иван");
            Console.WriteLine($"  Номер телефона 3: {phone3.GetNumber()}");
            Pause();

            Console.WriteLine("\nШаг 4: Вызываем метод SendMessage");
            phone1.SendMessage("89000000001", "89000000002", "89000000003");
            Pause();
        }

        static void RunVariant2()
        {
            Console.WriteLine("=== ВАРИАНТ 2 ===");
            Console.WriteLine("\nШаг 1: Создаем Person1");
            Person person1 = new Person("Петров Петр Петрович", 30);
            Console.WriteLine($" 'person1' создан. Имя: '{person1.FullName}', Возраст: {person1.Age}");
            Pause();

            Console.WriteLine("\nШаг 2: Создаем Person2");
            Person person2 = new Person("Иванов Иван Иванович", 25);
            Console.WriteLine($" 'person2' создан. Имя: '{person2.FullName}', Возраст: {person2.Age}");
            Pause();

            Console.WriteLine("\nШаг 3: Вызываем методы move() и talk() для 'person1'.");
            person1.Move();
            person1.Talk();
            Pause();

            Console.WriteLine("\nШаг 4: Вызываем методы move() и talk() для 'person2'.");
            person2.Move();
            person2.Talk();
            Pause();
        }

        static void RunVariant3()
        {
            Console.WriteLine("=== ВАРИАНТ 3 ===");
            try
            {
                Console.WriteLine("\nШаг 1: Создаем Матрицу M1 (2x2) и заполняем случайными числами.");
                Matrix m1 = new Matrix(2, 2);
                m1.FillRandom();
                Console.WriteLine("Матрица M1:");
                m1.Print();
                Pause();

                Console.WriteLine("\nШаг 2: Создаем Матрицу M2 (2x2) и заполняем случайными числами.");
                Matrix m2 = new Matrix(2, 2);
                m2.FillRandom();
                Console.WriteLine("Матрица M2:");
                m2.Print();
                Pause();

                Console.WriteLine("\nШаг 3: Выполняем сложение матриц (M1 + M2).");
                Matrix sumMatrix = m1.Add(m2);
                Console.WriteLine("Результат M1 + M2:");
                sumMatrix.Print();
                Pause();

                double scalar = 3.0;
                Console.WriteLine($"\nШаг 4: Выполняем умножение матрицы M1 на скалярное число.");
                Matrix scaledMatrix = m1.Multiply(scalar);
                Console.WriteLine($"Результат M1 * {scalar}:");
                scaledMatrix.Print();
                Pause();

                Console.WriteLine("\nШаг 5: Выполняем умножение матриц (M1 * M2).");
                Matrix productMatrix = m1.Multiply(m2);
                Console.WriteLine("Результат M1 * M2:");
                productMatrix.Print();
                Pause();

                Console.WriteLine("\nШаг 6: Демонстрация обработки ошибок (попытка сложить матрицы разных размеров).");
                Matrix m3_bad = new Matrix(2, 3);
                m3_bad.FillRandom();
                Console.WriteLine("Создана Матрица M3 (2x3):");
                m3_bad.Print();
                Pause();

                Console.WriteLine("Попытка сложить M1 (2x2) + M3 (2x3)...");
                m1.Add(m3_bad); 
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nОШИБКА: {ex.Message}");
                Console.WriteLine("Операции сложения/умножения матриц требуют совместимых размеров.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nПроизошла непредвиденная ошибка: {ex.Message}");
            }
            Pause();
        }

        static void RunVariant4()
        {
            Console.WriteLine("=== ВАРИАНТ 4 ===");
            Console.WriteLine("\nШаг 1: Создаем массив объектов класса Reader.");
            Reader[] libraryUsers = new Reader[]
            {
                new Reader("Петров В. В.", 101, "Информатика", new DateTime(2000, 5, 15), "8-900-111-22-33"),
                new Reader("Иванова А. С.", 102, "Экономика", new DateTime(2004, 11, 20), "8-922-333-44-55"),
                new Reader("Сидоров Н. М.", 103, "Юриспруденция", new DateTime(2002, 1, 10), "8-911-444-55-66")
            };
            Console.WriteLine("Массив из 3 читателей создан.");
            Pause();

            Console.WriteLine("\nШаг 2: Выводим информацию о каждом читателе.");
            foreach (var reader in libraryUsers)
            {
                reader.PrintInfo();
            }
            Pause();

            Console.WriteLine("\nШаг 3: Методы takeBook() и returnBook().");
            libraryUsers[0].TakeBook("Война и мир");
            libraryUsers[1].ReturnBook("Преступление и наказание");
            libraryUsers[0].TakeBook("Капитанская дочка");
            libraryUsers[2].ReturnBook("Евгений Онегин");
            Pause();
        }

        static void RunVariant5()
        {
            Console.WriteLine("=== ВАРИАНТ 5 ===");
            Console.WriteLine("\nШаг 1: Объявляем два объекта класса Tiles и вносим данные в поля.");
            Tiles tile1 = new Tiles("Kerama Marazzi", 60, 60, 1250.75m);
            Tiles tile2 = new Tiles("Atlas Concorde", 30, 90, 1800.00m);
            Console.WriteLine("Объекты плитки созданы и инициализированы.");
            Pause();

            Console.WriteLine("\nШаг 2: Отображаем данные первого объекта, вызвав метод getData().");
            tile1.GetData();
            Pause();

            Console.WriteLine("\nШаг 3: Отображаем данные второго объекта, вызвав метод getData().");
            tile2.GetData();
            Pause();
        }

        static void RunVariant6()
        {
            Console.WriteLine("=== ВАРИАНТ 6 ===");
            Console.WriteLine("\nШаг 1: Объявляем два объекта класса Children.");
            Children child1 = new Children();
            Children child2 = new Children();
            Console.WriteLine("Два объекта Children созданы.");
            Pause();

            Console.WriteLine("\nШаг 2: Вносим данные для первого ребенка с помощью публичного метода InputData().");
            child1.InputData();
            Pause();

            Console.WriteLine("\nШаг 3: Вносим данные для второго ребенка с помощью публичного метода InputData().");
            child2.InputData();
            Pause();

            Console.WriteLine("\nШаг 4: Отображаем данные первого ребенка с помощью публичного метода DisplayData().");
            child1.DisplayData();
            Pause();

            Console.WriteLine("\nШаг 5: Отображаем данные второго ребенка с помощью публичного метода DisplayData().");
            child2.DisplayData();
            Pause();
        }

        static void RunVariant7()
        {
            Console.WriteLine("=== ВАРИАНТ 7 ===");
            Console.WriteLine("\nШаг 1: Создаем объект класса Cube.");
            double side = 0;
            Console.Write("Введите длину стороны куба ");
            while (!double.TryParse(Console.ReadLine(), out side) || side <= 0)
            {
                Console.Write("Некорректный ввод. Введите положительное число для стороны куба: ");
            }

            Cube myCube = new Cube(side);
            Console.WriteLine($"Объект куба создан со стороной {myCube.SideLength}.");
            Pause();

            Console.WriteLine("\nШаг 2: Выводим состояние объекта куба (длина стороны, площадь грани, площадь поверхности, объем).");
            myCube.PrintState();
            Pause();
        }

        static void RunVariant8()
        {
            Console.WriteLine("=== ВАРИАНТ 8 ===");
            Console.WriteLine("\nШаг 1: Создаем счетчик по умолчанию (от 0 до 10, начальное 0).");
            DecimalCounter defaultCounter = new DecimalCounter();
            Console.WriteLine($"Текущее значение счетчика по умолчанию: {defaultCounter.State}");
            Pause();

            Console.WriteLine("\nШаг 2: Создаем счетчик с произвольными значениями (от 5 до 15, начальное 8).");
            DecimalCounter customCounter = new DecimalCounter(8, 5, 15);
            Console.WriteLine($"Текущее значение произвольного счетчика: {customCounter.State}");
            Pause();

            Console.WriteLine("\nШаг 3: Тестируем метод Increment() для произвольного счетчика.");
            Console.WriteLine($"Начальное значение: {customCounter.State}");
            customCounter.Increment(); 
            customCounter.Increment(); 
            customCounter.Increment(); 
            Console.WriteLine($"Текущее значение после нескольких увеличений: {customCounter.State}");
            Pause();

            Console.WriteLine("\nШаг 4: Тестируем метод Decrement() для произвольного счетчика.");
            customCounter.Decrement(); 
            customCounter.Decrement(); 
            Console.WriteLine($"Текущее значение после нескольких уменьшений: {customCounter.State}");
            Pause();

            Console.WriteLine("\nШаг 5: Доводим счетчик до максимума и пытаемся увеличить еще раз.");
            for (int i = 0; i < 7; i++) customCounter.Increment();
            customCounter.Increment(); 
            Pause();

            Console.WriteLine("\nШаг 6: Доводим счетчик до минимума и пытаемся уменьшить еще раз.");
            for (int i = 0; i < 10; i++) customCounter.Decrement(); 
            customCounter.Decrement(); 
            Pause();
        }

        static void RunVariant9()
        {
            Console.WriteLine("=== ВАРИАНТ 9 ===");
            TimeClass myTime;
            Console.WriteLine("\nШаг 1: Создаем объект TimeClass и устанавливаем начальное время.");
            try
            {
                myTime = new TimeClass(23, 33, 30);
                Pause();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка при инициализации времени: {ex.Message}");
                return;
            }

            Console.WriteLine("\nШаг 2: Изменяем время, добавляя заданное количество секунд (добавляем 90 секунд).");
            myTime.AddSeconds(90); 
            Pause();

            Console.WriteLine("\nШаг 3: Изменяем время, добавляя заданное количество минут (добавляем 65 минут).");
            myTime.AddMinutes(65);
            Pause();

            Console.WriteLine("\nШаг 4: Изменяем время, добавляя заданное количество часов (добавляем 3 часа).");
            myTime.AddHours(3); 
            Pause();

            Console.WriteLine("\nШаг 5: Демонстрация обработки исключений при попытке установки неверного времени.");
            try
            {
                Console.WriteLine("Попытка установить часы = 25...");
                myTime.SetTime(25, 0, 0);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"ОШИБКА: {ex.Message}");
                Console.WriteLine($"Текущее время осталось: {myTime.ToString()}");
            }
            Pause();
        }

        static void RunVariant10()
        {
            Console.WriteLine("=== ВАРИАНТ 10 ===");
            try
            {
                Console.WriteLine("\nШаг 1: Создаем объект Triangle (прямоугольный треугольник со сторонами 3, 4, 5).");
                Triangle tri = new Triangle(0, 0, 4, 0, 0, 3);
                Console.WriteLine("Треугольник успешно создан с вершинами (0,0), (4,0), (0,3).");
                Pause();

                Console.WriteLine("\nШаг 2: Выводим все свойства объекта (длины сторон, периметр, площадь, координаты центроида).");
                tri.PrintState();
                Pause();

                Console.WriteLine("\nШаг 3: Демонстрация обработки исключений при попытке создать вырожденный треугольник.");
                Console.WriteLine("Попытка создать треугольник с точками (0,0), (1,1), (2,2) - эти точки лежат на одной прямой...");
                Triangle degenerateTri = new Triangle(0, 0, 1, 1, 2, 2);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nОШИБКА: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nПроизошла непредвиденная ошибка: {ex.Message}");
            }
            Pause();
        }

        static void RunVariant11()
        {
            Console.WriteLine("=== ВАРИАНТ 11 ===");
            Console.WriteLine("\nШаг 1: Создаем список студентов ");
            List<Student> students = new List<Student>
            {
                new Student("Клепалова", "Александра", "Александровна", "ИС-24", "ИсИл", 2, "8-900-100-00-01"),
                new Student("Михайлова", "Кристина", "Алексеевна", "ИС-24", "ИсИл", 2, "8-900-100-00-02"),
                new Student("Каширина", "Карина", "Евгеньевна", "ИС-24", "ИсИл", 2, "8-900-100-00-03"),
                new Student("Козлов", "Олег", "Петрович", "ЭБАС-23", "ИТ", 3, "8-900-100-00-04"),
                new Student("Смирнова", "Елена", "Николаевна", "ЭБАС-23", "ИТ", 3, "8-900-100-00-05"),
                new Student("Федоров", "Кирилл", "Андреевич", "ЭБАС-23", "ИТ", 3, "8-900-100-00-06")
            };
            Console.WriteLine($"Создано {students.Count} студентов и добавлены в список.");
            Pause();

            Console.WriteLine("\nШаг 2: Выводим полную информацию о каждом студенте в списке.");
            foreach (var student in students)
            {
                student.PrintStudentInfo();
                Console.WriteLine("--------------------");
            }
            Pause();

            Console.WriteLine("\nШаг 3: Вызываем статический метод DisplayStudentsInGroup для группы 'ИС-24'.");
            Student.DisplayStudentsInGroup("ИС", "24", students);
            Pause();

            Console.WriteLine("\nШаг 4: Вызываем статический метод DisplayStudentsInGroup для группы 'ЭБАС-23'.");
            Student.DisplayStudentsInGroup("ЭБАС", "23", students);
            Pause();

            Console.WriteLine("\nШаг 5: Вызываем статический метод DisplayStudentsInGroup для несуществующей группы 'ОДЛ-22'.");
            Student.DisplayStudentsInGroup("ОДЛ", "22", students);
            Pause();
        }

        static void RunVariant12()
        {
            Console.WriteLine("=== ВАРИАНТ 12 ===");
            Console.WriteLine("\nШаг 1: Создаем список различных компьютерных компонентов.");
            List<Hardware> components = new List<Hardware>
            {
                new Hardware("Процессор", "Intel", "Core i9-13900K", 1000, 55000.00m),
                new Hardware("Процессор", "AMD", "Ryzen 9 7950X", 980, 50000.00m),
                new Hardware("Видеокарта", "NVIDIA", "RTX 4090", 1500, 180000.00m),
                new Hardware("Видеокарта", "AMD", "RX 7900 XTX", 1200, 120000.00m),
                new Hardware("ОЗУ", "Kingston", "Fury Beast 32GB", 80, 12000.00m),
                new Hardware("ОЗУ", "Corsair", "Vengeance 32GB", 75, 11000.00m),
                new Hardware("Блок питания", "Seasonic", "Focus GX-850", 50, 10000.00m),
                new Hardware("Блок питания", "be quiet!", "Pure Power 11 700W", 40, 8000.00m),
                new Hardware("Материнская плата", "ASUS", "ROG Strix Z790-E", 90, 35000.00m),
                new Hardware("Материнская плата", "Gigabyte", "B650 AORUS Elite AX", 70, 20000.00m),
                new Hardware("Охлаждение", "NZXT", "Kraken Z73", 60, 15000.00m),
                new Hardware("Охлаждение", "Noctua", "NH-D15", 55, 10000.00m)
            };
           

            Console.WriteLine("\nШаг 2: Выводим информацию о всех компонентах.");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            foreach (var comp in components)
            {
                comp.PrintInfo();
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Pause();

            Console.WriteLine("\nШаг 3: Находим самый мощный компонент из всего списка с помощью GetMostPowerfulComponent().");
            Hardware mostPowerfulComponent = Hardware.GetMostPowerfulComponent(components);
            mostPowerfulComponent?.PrintInfo();
            Pause();

            Console.WriteLine("\nШаг 4: Находим самый дешёвый компонент из всего списка с помощью GetCheapestComponent().");
            Hardware cheapestComponent = Hardware.GetCheapestComponent(components);
            cheapestComponent?.PrintInfo();
            Pause();

            Console.WriteLine("\nШаг 5: Формируем 'самую мощную сборку' с помощью GetMostPowerfulBuild().");
            Dictionary<string, Hardware> mostPowerfulBuild = Hardware.GetMostPowerfulBuild(components);
            decimal totalPowerfulPrice = 0;
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            foreach (var entry in mostPowerfulBuild)
            {
                entry.Value.PrintInfo();
                totalPowerfulPrice += entry.Value.Price;
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine($"Общая стоимость самой мощной сборки: {totalPowerfulPrice:C}");
            Pause();

            Console.WriteLine("\nШаг 6: Формируем 'самую дешёвую сборку' с помощью GetCheapestBuild().");
            Dictionary<string, Hardware> cheapestBuild = Hardware.GetCheapestBuild(components);
            decimal totalCheapestPrice = 0;
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            foreach (var entry in cheapestBuild)
            {
                entry.Value.PrintInfo();
                totalCheapestPrice += entry.Value.Price;
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine($"Общая стоимость самой дешевой сборки: {totalCheapestPrice:C}");
            Pause();
        }

        static void RunVariant13()
        {
            Console.WriteLine("=== ВАРИАНТ 13 ===");
            Console.WriteLine("\nШаг 1: Создаем объект Runner 'Алексей' и инициализируем его данные.");
            Runner runner1 = new Runner("Алексей", 175, 70, 10000, 140, 500);
            runner1.PrintRunnerInfo();
            Pause();

            Console.WriteLine("\nШаг 2: Вычисляем дистанцию, пробежанную 'Алексеем', с помощью CalculateDistance().");
            double distance1 = runner1.CalculateDistance();
            Console.WriteLine($"  'Алексей' пробежал: {distance1:F2} км");
            Pause();

            Console.WriteLine("\nШаг 3: Создаем второй объект Runner 'Мария' с другими параметрами.");
            Runner runner2 = new Runner("Мария", 160, 55, 12000, 130, 450); 
            runner2.PrintRunnerInfo();
            Pause();

            Console.WriteLine("\nШаг 4: Вычисляем дистанцию, пробежанную 'Марией'.");
            double distance2 = runner2.CalculateDistance();
            Console.WriteLine($"  'Мария' пробежала: {distance2:F2} км");
            Pause();
        }

        static void RunVariant14()
        {
            Console.WriteLine("=== ВАРИАНТ 14 ===");
            try
            {
                Console.WriteLine("\nШаг 1: Создаем объект SquarePyramid, запросив параметры у пользователя.");
                double baseSide = 0, height = 0;

                Console.Write("Введите длину стороны основания пирамиды ");
                while (!double.TryParse(Console.ReadLine(), out baseSide) || baseSide <= 0)
                {
                    Console.Write("Некорректный ввод. Введите положительное число: ");
                }

                Console.Write("Введите высоту пирамиды ");
                while (!double.TryParse(Console.ReadLine(), out height) || height <= 0)
                {
                    Console.Write("Некорректный ввод. Введите положительное число: ");
                }

                SquarePyramid pyramid = new SquarePyramid(baseSide, height);
                Console.WriteLine($"Объект пирамиды успешно создан со стороной основания {pyramid.BaseSide} и высотой {pyramid.Height}.");
                Pause();

                Console.WriteLine("\nШаг 2: Выводим все свойства и расчетные значения объекта ");
                pyramid.PrintState();
                Pause();

                Console.WriteLine("\nШаг 3: Демонстрация обработки исключений при попытке создать пирамиду с неверными параметрами.");
                Console.WriteLine("Попытка создать пирамиду с отрицательной стороной основания (-5)...");
                SquarePyramid invalidPyramid = new SquarePyramid(-5, 10); 
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nОШИБКА: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nПроизошла непредвиденная ошибка: {ex.Message}");
            }
            Pause();
        }
    }
}
