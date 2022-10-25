using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UML_Editor_Nguyen.Relationship_Components;

namespace UML_Editor_Nguyen
{
    public class UML_Class_Code_Exporter
    {
        public List<string> GetNamespaces(UML_Class_Object classObj)
        {
            HashSet<string> namespaces = new HashSet<string>();

            classObj.Description_Component.Methods.ForEach(item =>
            {
                item.Parameters.ForEach(item2 =>
                {
                    namespaces.Add($"using {item2.DataType.Namespace};");
                });

                if (!item.IsVoid)
                {
                    namespaces.Add($"using {item.ReturnType.Namespace};");
                }
            });

            classObj.Description_Component.Properties.ForEach(item =>
            {
                namespaces.Add($"using {item.DataType.Namespace};");
            });

            return namespaces.ToList();
        }

        public List<string> GetProperties(UML_Class_Object classObj)
        {
            List<string> properties = new List<string>();

            classObj.Description_Component.Properties.ForEach(item =>
            {
                properties.Add($"\t\t{item.Modifier} {item.DataType.Name} {item.PropertyName} {{ get; set; }}");
            });

            return properties;
        }

        public List<string> GetMethods(UML_Class_Object classObj)
        {
            List<string> methods = new List<string>();

            if (classObj.Description_Component.Stereotype == "Interface")
            {
                classObj.Description_Component.Methods.ForEach(item =>
                {
                    string parameters = String.Join(", ", item.Parameters.Select(item => $"{item.DataType.Name} {item.ParameterName}"));

                    if (item.IsVoid)
                    {
                        methods.Add($"\t\t{item.Modifier} void {item.MethodName}({parameters});");
                    }
                    else
                    {
                        methods.Add($"\t\t{item.Modifier} {item.ReturnType.Name} {item.MethodName}({parameters});");
                    }
                });
            }
            else
            {
                classObj.Description_Component.Methods.ForEach(item =>
                {
                    string parameters = String.Join(", ", item.Parameters.Select(item => $"{item.DataType.Name} {item.ParameterName}"));

                    if (item.IsVoid)
                    {
                        methods.Add($"\t\t{item.Modifier} void {item.MethodName}({parameters}) \r\n\t\t{{\r\n\t\t\tthrow new NotImplementedException();\r\n\t\t}}");
                    }
                    else
                    {
                        methods.Add($"\t\t{item.Modifier} {item.ReturnType.Name} {item.MethodName}({parameters}) \r\n\t\t{{\r\n\t\t\tthrow new NotImplementedException();\r\n\t\t}}");
                    }
                });
            }

            return methods;
        }

        public List<string> GetClassHeaderAndImplementations(UML_Class_Object classObj, UML_Editor_Engine parentWrapper)
        {
            List<string> header = new List<string>();
            List<UML_Relationship> relationships = parentWrapper.relationships
                .Where(item => item.Primary_Class == classObj || item.Secondary_Class == classObj).ToList();

            List<string> inheritsFrom = new List<string>();
            List<string> multiplicities = new List<string>();
            List<string> implementedMethodsAndProps = new List<string>();

            relationships.ForEach(item =>
            {
                if (item.Description_Component.lineType.TypeName == "Inheritance" && item.Primary_Class == classObj)
                {
                    inheritsFrom.Add(item.Secondary_Class.Description_Component.ClassName);
                }

                

                if (item.Primary_Class == classObj && item.Secondary_Class.Description_Component.Stereotype == "Interface")
                {
                    item.Secondary_Class.Description_Component.Methods.ForEach(item2 =>
                    {
                        string parameters = String.Join(", ", item2.Parameters.Select(item => $"{item.DataType.Name} {item.ParameterName}"));

                        if (item2.IsVoid)
                            implementedMethodsAndProps.Add($"\t\tpublic void {item2.MethodName}({parameters}) \r\n\t\t{{\r\n\t\t\tthrow new NotImplementedException();\r\n\t\t}}");
                        else
                            implementedMethodsAndProps.Add($"\t\tpublic {item2.ReturnType.Name} {item2.MethodName}({parameters}) \r\n\t\t{{\r\n\t\t\tthrow new NotImplementedException();\r\n\t\t}}");

                    });

                    item.Secondary_Class.Description_Component.Properties.ForEach(item3 =>
                    {
                        implementedMethodsAndProps.Add($"\t\tpublic {item3.DataType.Name} {item3.PropertyName} {{ get; set; }}");
                    });
                }


            });
            
            if (inheritsFrom.Count > 0)
            {
                if (classObj.Description_Component.Stereotype == "Interface")
                {
                    header.Add($"\tpublic interface {classObj.Description_Component.ClassName}: {String.Join(",", inheritsFrom)} \r\n{{");
                }
                else
                {
                    header.Add($"\tpublic class {classObj.Description_Component.ClassName}: {String.Join(",", inheritsFrom)} \r\n{{");
                }
            }
            else
            {
                if (classObj.Description_Component.Stereotype == "Interface")
                {
                    header.Add($"\tpublic interface {classObj.Description_Component.ClassName} \r\n{{");
                }
                else
                {
                    header.Add($"\tpublic class {classObj.Description_Component.ClassName} \r\n{{");
                }
            }
            
            header.AddRange(multiplicities);
            header.AddRange(implementedMethodsAndProps);

            return header;
        }
        public void ExportToCode(string namespaceStr, string folderpath, UML_Editor_Engine engine)
        {
            foreach (UML_Class_Object item in engine.classes)
            {
                List<string> outPut = new List<string>();

                outPut.AddRange(this.GetNamespaces(item));
                outPut.Add("");
                outPut.Add($"namespace {namespaceStr} {{");
                outPut.AddRange(this.GetClassHeaderAndImplementations(item, engine));
                outPut.AddRange(this.GetProperties(item));
                outPut.Add("");
                outPut.AddRange(this.GetMethods(item));
                outPut.Add("\t}");
                outPut.Add("}");

                this.WriteAll(folderpath, item.Description_Component.ClassName, outPut);
            }

        }

        public void WriteAll(string folderpath, string className, List<string> classOutput)
        {
            if (!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
            }

            using (StreamWriter writer = new StreamWriter(folderpath+"/"+className+".cs"))
            {
                foreach (string line in classOutput)
                {
                    writer.WriteLine(line);
                }

                writer.Close();
            }
        }
    }
}
