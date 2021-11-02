namespace Lab05_pl
{
    abstract class Shape2D
    {
        protected readonly int objectNumber;
        static int classCounter = 0;

        public Shape2D() 
        {
            this.objectNumber = ++classCounter;
            System.Console.WriteLine($"Shape2D({objectNumber}) created");
        }
        ~Shape2D() 
        {
            System.Console.WriteLine($"Shape2D({objectNumber}) destroyed");
        }
        public abstract double CalculateArea();
        virtual public string PrintShape2D()
        {
            return "Shape(Shape2D)";
        }
    }

    class Circle : Shape2D
    {
        double radius;
        public Circle(double radius) : base()
        {
            this.radius = radius;
            System.Console.WriteLine($"Circle({objectNumber}) with radius={radius} created");
        }
        ~Circle()
        {
            System.Console.WriteLine($"Circle({objectNumber}) destroyed");
        }
        public override double CalculateArea()
        {
            return radius * radius * System.Math.PI;
        }
        override public string PrintShape2D()
        {
            return $"Circle(r={radius})";
        }
    }

    abstract class Shape3D
    {
        public static int NumberOfCreatedObjects = 0;
        protected int objectNumber;
        protected Shape2D baseShape;
        protected double height;
        public Shape3D(Shape2D baseShape, double height)
        {
            this.baseShape = baseShape;
            this.height = height;
            objectNumber = ++NumberOfCreatedObjects;
        }
        public abstract double CalculateCapacity();
        virtual public string PrintShape3D()
        {
            return $"Shape3D with base {baseShape.PrintShape2D()} and height: {height}";
        }
    }

    class Cylinder : Shape3D
    {
        new public static int NumberOfCreatedObjects = 1;
        public Cylinder(Circle circle, double height) : base(circle, height)
        {
        }
        override public double CalculateCapacity()
        {
            return baseShape.CalculateArea() * height;
        }
        public new string PrintShape3D()
        {
            return $"Cylinder(h={height}) with base: {baseShape.PrintShape2D()}";
        }
    }

    class Cone : Shape3D
    {
        new public static int NumberOfCreatedObjects = 0;
        public Cone(Circle circle, double height) : base(circle, height)
        {
            NumberOfCreatedObjects++;
        }
        override public double CalculateCapacity()
        {
            return baseShape.CalculateArea() * height / 3;
        }
        override public string PrintShape3D()
        {
            return $"Cone(h={height}) with base: {baseShape.PrintShape2D()}";
        }
    }
}
