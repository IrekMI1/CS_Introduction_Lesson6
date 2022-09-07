// задача 40 - HARD необязательная. На вход программы подаются три целых положительных числа. 
// Определить , является ли это сторонами треугольника. Если да, то вывести всю информацию по нему - площадь, 
//периметр, значения углов треугольника в градусах, является ли он прямоугольным, равнобедренным, равносторонним.

bool IsTriangle(double[] sides)
{   
    if (sides[0] < sides[1] + sides[2] 
        && sides[1] < sides[0] + sides[2] 
        && sides[2] < sides[1] + sides[0]) 
    {
        return true;
    }
    else return false;
}

double[] GetAnglesArray(double[] sides)
{
    double a = sides[0];
    double b = sides[1];
    double c = sides[2];
    
    double acAngle = Math.Acos((Math.Pow(a, 2) 
                                + Math.Pow(c, 2) 
                                - Math.Pow(b, 2)) 
                                / (2 * a * c))
                                * (180 / Math.PI);  // из теоремы косинусов
    
    double abAngle = Math.Acos((Math.Pow(a, 2) 
                                + Math.Pow(b, 2) 
                                - Math.Pow(c, 2)) 
                                / (2 * a * b))
                                * (180 / Math.PI);

    double bcAngle = 180.0 - acAngle - abAngle;
    return new double[] {acAngle, abAngle, bcAngle};
}

void PrintTriangleProperties(double[] sides)
{
    double perimeter = sides.Sum();
    double square = Math.Sqrt(perimeter / 2               
                            * (perimeter / 2 - sides[0])
                            * (perimeter / 2 - sides[1])
                            * (perimeter / 2 - sides[2]));      // формула Герона
        
    double[] angles = GetAnglesArray(sides);

    if (Array.Exists(angles, angle => angle == 90.0)) Console.Write("Треугольник прямоугольный, ");
    else Console.Write("Треугольник не прямоугольный, ");

    if (sides[0] == sides[1]
        || sides[0] == sides[2]
        || sides[1] == sides[2])
    {
        Console.Write("равнобедренный, ");
    }
    else Console.Write("неравнобедренный, ");

    if (sides[0] == sides[1] && sides[0] == sides[2]) Console.WriteLine("равносторонний.");
    else Console.WriteLine("неравносторонний. ");

    Console.WriteLine($"Площадь: \t{Math.Round(square, 3)}");
    Console.WriteLine($"Периметр: \t{Math.Round(perimeter, 3)}");
    Console.Write($"Угол а с: \t{Math.Round(angles[0], 2)} \n");
    Console.Write($"Угол а b: \t{Math.Round(angles[1], 2)} \n");
    Console.Write($"Угол b с: \t{Math.Round(angles[2], 2)} \n");
}

try
{
    Console.Write("Введите 3 целых положительных числа через ' ':\t");
    double[] sides = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();
    if (IsTriangle(sides))
    {
        Console.WriteLine($"Является треугольником со сторонами: а = {sides[0]}, b = {sides[1]}, c = {sides[2]}");
        PrintTriangleProperties(sides);
    }
    else Console.WriteLine("Не может быть треугольником.");
}
catch
{
    Console.WriteLine("Ошибка ввода!");
}