using System;

using CreationalDesignPatterns.BuilderCodingExercise.Models;
using CreationalDesignPatterns.BuilderCodingExercise.Types;
using CreationalDesignPatterns.BuilderCodingExercise.Builders;

namespace CreationalDesignPatterns.BuilderCodingExercise{

    public class Program{
        public static void Main(string[] args)
        {
            CodeBuilder codeBuilder = new CodeBuilder("Person")
                .AddField("Name", AccessLevels.@public, DataTypes.@string)
                .AddField("Age", AccessLevels.@private, DataTypes.@int)
                .AddField("IsAlive", AccessLevels.@protected, DataTypes.@bool)
                .AddField("Height", AccessLevels.@public, DataTypes.@float);

            string code = codeBuilder.Build();
            Console.WriteLine(code);
        }

    }
}