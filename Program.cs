using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("The path of assembly");
        FileInfo fileInfo = new FileInfo(Console.ReadLine());

        Assembly assembly = Assembly.LoadFrom(fileInfo.FullName);

        Type type = assembly.GetType();

        Console.WriteLine(type);

        foreach(Type t in type.GetInterfaces())
            Console.WriteLine(t.Name);

        foreach (MethodInfo method in type.GetMethods(BindingFlags.DeclaredOnly 
                                                    | BindingFlags.Public 
                                                    | BindingFlags.Instance 
                                                    | BindingFlags.Static
                                                    | BindingFlags.NonPublic))
        {
            string mode = "";
            if (method.IsPublic)
                mode += "public";
            else if (method.IsPrivate)
                mode += "private";
            else if (method.IsFamily)
                mode += "protected";
            else if (method.IsAssembly)
                mode += "internal";       
            else if (method.IsConstructor)
                mode += "constructor";
            else if (method.IsAbstract)
                mode += "abstract";
            Console.WriteLine($"{mode}{method.ReturnType.FullName} ({method.GetParameters})");
        }
    }
}
//checked
