using System;
using System.Reflection;

class Program {
    static void Main() {
        try {
            var asm = Assembly.LoadFrom(@"d:\Semester_8_SP26\SmartRecruit\SmartRecruit.API\bin\Debug\net8.0\Serilog.Enrichers.Sensitive.dll");
            var t = asm.GetType("Serilog.Enrichers.Sensitive.MaskProperty");
            if(t != null) {
                Console.WriteLine("Type: " + t.FullName);
                Console.WriteLine("IsEnum: " + t.IsEnum);
                foreach(var f in t.GetFields()) Console.WriteLine("Field: " + f.Name + " Type: " + f.FieldType);
                foreach(var c in t.GetConstructors()) Console.WriteLine("Constructor: " + c.ToString());
            } else {
                Console.WriteLine("Type not found");
            }
        } catch (Exception ex) {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
