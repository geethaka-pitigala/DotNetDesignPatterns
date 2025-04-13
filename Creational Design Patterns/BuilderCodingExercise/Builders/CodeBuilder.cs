using System.Text;

using CreationalDesignPatterns.BuilderCodingExercise.Models;
using CreationalDesignPatterns.BuilderCodingExercise.Types;

namespace CreationalDesignPatterns.BuilderCodingExercise.Builders
{
    public class CodeBuilder
    {
        private string _className;
        private int _indentation = 4;
        private List<Field> _fields = new List<Field>();
        
        public CodeBuilder(string ClassName){
            this._className = ClassName;
        }
        
        public CodeBuilder AddField(string fieldName, AccessLevels access, DataTypes dataType){
            this._fields.Add(new Field{
                Access = access,
                Type = dataType,
                FieldName = fieldName,
            });
            
            return this;
        }
        
        public string Build(){
            var sb = new StringBuilder();
            sb.AppendFormat("public class {0} {{\n", _className);
            string indent = new string(' ', _indentation);
            
            foreach(Field field in _fields){
                sb.AppendFormat("{0} {1} {2} {3};\n", 
                    indent, 
                    field.Access,
                    field.Type,
                    field.FieldName
                    );
            }
            
            sb.Append("}");
            
            return sb.ToString();
            
        }
    }
}