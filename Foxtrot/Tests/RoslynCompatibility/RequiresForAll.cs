// CodeContracts
// 
// Copyright (c) Microsoft Corporation
// 
// All rights reserved. 
// 
// MIT License
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using System.Threading;

namespace Tests.Sources
{

    [ContractClass(typeof(FooContracts))]
    public interface IFoo
    {
        void Method(params string[] strings);
    }

    [ContractClassFor(typeof(IFoo))]
    public abstract class FooContracts : IFoo
    {
        public void Method(params string[] strings)
        {
            Contract.Requires(Contract.ForAll(strings, s => s.Length > 0));
        }
    }

    public class Foo : IFoo
    {
        public void Method(params string[] strings)
        {
            Console.WriteLine("Method({0}", string.Join(", ", strings));
        }
    }


    public class Booo
    {
        public void Method(params string[] strings)
        {
            Contract.Requires(Contract.ForAll(strings, s => s.Length > 0));
        }
    }

  partial class TestMain
  {
    partial void Run()
    {
      if (behave)
      {
        new Foo().Method("1", "2", "3");
      }
      else
      {
        new Foo().Method("1", "");
      }
    }

    public ContractFailureKind NegativeExpectedKind = ContractFailureKind.Precondition;
    public string NegativeExpectedCondition = "Contract.ForAll(strings, s => s.Length > 0)";
  }

#if NETFRAMEWORK_3_5
  public class Lazy<T> {
    Func<T> delay;
    public Lazy(Func<T> delay) {
      this.delay = delay;
    }

    public T Value { get { return this.delay(); } }
  }
#endif
}
