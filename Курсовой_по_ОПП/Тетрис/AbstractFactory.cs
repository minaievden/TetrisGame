﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Курсовой_по_ОПП.Тетрис
{
    public class Singleton<T> where T : class
{
  /// Защищённый конструктор необходим для того, чтобы предотвратить создание экземпляра класса Singleton. 
  /// Он будет вызван из закрытого конструктора наследственного класса.
  protected Singleton() { }
 
  /// Фабрика используется для отложенной инициализации экземпляра класса
  private sealed class SingletonCreator<S> where S : class
  {
    //Используется Reflection для создания экземпляра класса без публичного конструктора
    private static readonly S instance = (S) typeof(S).GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                new Type[0],
                new ParameterModifier[0]).Invoke(null);
 
    public static S CreatorInstance
    {
      get { return instance; }
    }
  }
 
  public static T Instance
  {
    get { return SingletonCreator<T>.CreatorInstance; }
  }
 
}
 
/// Использование Singleton
public class TestClass : Singleton<TestClass>
{
    /// Вызовет защищенный конструктор класса Singleton
    private TestClass() { }
 
    public string TestProc()
    {
        return "Hello World";
    }

  }
 
}

