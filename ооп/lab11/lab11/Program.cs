using System.Reflection;


namespace lab11
{
     static class Reflector
    {
        static string path = "file.txt";
        static void FileCreate()
        {
            File.Create(path);
        }

        public static string AssemblyName(object t)
        {
            Type type = t.GetType();
            using (StreamWriter swo = new StreamWriter(path, true))
            { swo.WriteLine(type.Assembly.FullName); }
            return type.Assembly.FullName;
        }
        public static bool IsPubConstr(object t)
        {
            var constructors =t.GetType().GetConstructors();
            if (constructors.Length > 0) { return true; }
            return false;

        }

        public static List<string> GetPublicMeth(object t)
        {
            Type t2 = t.GetType();
            List<string> list = new List<string>();
            var methods = t2.GetMethods();
            foreach (var m in methods)
            {
                list.Add(m.Name);
            }
            using (StreamWriter swo = new StreamWriter(path, true))
            {
                foreach (var item in list)
                {
                    swo.WriteLine(item);
                };
            }
            return list;
        }
        public static List<string> publicPropAndFields(object t)
        {
            Type t2 = t.GetType();
            List<string> list = new List<string>();
            var props = t2.GetProperties();
            var fields = t2.GetFields();
            foreach (var m in props)
            {
                list.Add(m.Name);
            }
            foreach (var m in fields)
            {
                list.Add(m.Name);
            }
            using (StreamWriter swo = new StreamWriter(path, true))
            {
                foreach (var item in list)
                {
                    swo.WriteLine(item);
                };
            }
            return list;
        }
        public static List<string> GetInterfaces(object t)
        {
            Type t2 = t.GetType();
            List<string> list = new List<string>();
            var interfaces = t2.GetInterfaces();
            foreach (var m in interfaces)
            {
                list.Add(m.Name);
            }
            using (StreamWriter swo = new StreamWriter(path, true))
            {
                foreach (var item in list)
                {
                    swo.WriteLine(item);
                };
            }
            return list;
        }
        public static void PrintMeth(object t, object p)
        {
            Type t2 = t.GetType();
            Type p1 = p.GetType();
            List<string> list = new List<string>();
            var methods = t2.GetMethods();
            foreach (var m in methods)
            {
                bool check = false;
                var parms = m.GetParameters();
                foreach (var p2 in parms)
                {
                    if (p2.ParameterType == p1) { check = true; break; }
                }

                if (check) { Console.WriteLine(m.Name); }
            }
        }
        public static void Invoke(object t, string name, object[] parm)
        {
            {
                Type t2 = t.GetType(); var method = t2.GetMethod(name); if (method == null) { return; } 
                string[] lines = File.ReadAllLines(path);
                ParameterInfo[] parameterInfos = method.GetParameters();
                object[] parameters = new object[parameterInfos.Length];
                for (int i = 0; i < parameterInfos.Length; i++)
                {
                    if (i < lines.Length)
                    { parameters[i] = Convert.ChangeType(lines[i], parameterInfos[i].ParameterType); }
                    else { parameters[i] = GetDefaultValue(parameterInfos[i].ParameterType); }
                }
                method.Invoke(t, parameters);
            }
        }
            private static object GetDefaultValue(Type type) 
            { 
            if (type.IsValueType) { 
                return Activator.CreateInstance(type);
            } 
            return null;
        }
            

        public static object Create(object t, object[] parm)
        {
            Type type = t.GetType();
            var obj = Activator.CreateInstance(type, parm);
            return obj;
        }

    }
}