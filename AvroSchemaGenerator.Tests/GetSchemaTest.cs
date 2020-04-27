﻿using System.Collections.Generic;
using System.ComponentModel;
using Xunit;
using Xunit.Abstractions;

namespace AvroSchemaGenerator.Tests
{
    public class GetSchemaTest
    {
        private readonly ITestOutputHelper _output;

        public GetSchemaTest(ITestOutputHelper output)
        {
            this._output = output;
        }
        [Fact]
        public void TestSimpleFoo()
        {
            var simple = typeof(SimpleFoo).GetSchema();
            _output.WriteLine(simple);
            Assert.Contains("Age", simple);
        }

        [Fact]
        public void TestFoo()
        {
            var simple = typeof(Foo).GetSchema();
            _output.WriteLine(simple);
            Assert.Contains("Age", simple);
        }
        [Fact]
        public void TestFooCustom()
        {
            var simple = typeof(FooCustom).GetSchema();
            _output.WriteLine(simple);
            Assert.Contains("EntryYear", simple);
            Assert.Contains("Level", simple);
        }
    }

    public class SimpleFoo
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public long FactTime { get; set; }
        public double Point { get; set; }
        public float Precision { get; set; }
        public bool Attending { get; set; }
        public byte[] Id { get; set; }
    }
    public class Foo
    {
        public SimpleFoo Fo { get; set; }
        public List<string> Courses { get; set; }
        public Dictionary<string, string> Normal { get; set; }

    }
    public class FooCustom
    {
        public SimpleFoo Fo { get; set; }
        public List<Course> Courses { get; set; }
        public Dictionary<string, Lecturers> Departments { get; set; }
    }

    public class Course
    {
        [DefaultValue("200")]
        public string Level { get; set; }
        [DefaultValue(2020)]
        public int Year { get; set; } 
    }

    public class Lecturers
    {
        public int EntryYear { get; set; }
        public string Name { get; set; }
    }
}
