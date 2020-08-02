using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace P01_Stealer
{
    public class Spy
    {

        public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
        {
            var stringBuilder = new StringBuilder($"Class under investigation: {classToInvestigate}"
                                                  + Environment.NewLine);
            var fields = Type.GetType(classToInvestigate)
                .GetFields(BindingFlags.Instance
                           | BindingFlags.Static
                           | BindingFlags.NonPublic
                           | BindingFlags.Public);
            var instanceClass = Activator.CreateInstance(Type.GetType(classToInvestigate));

            foreach (var field in fields.Where(f => fieldsToInvestigate.Contains(f.Name)))
            {
                stringBuilder.AppendLine($"{field.Name} = {field.GetValue(instanceClass)}");
            }
            return stringBuilder.ToString().Trim();
        }
    }
}
