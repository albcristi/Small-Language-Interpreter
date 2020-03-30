using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using ToyLanguage.ControllerPack;
using ToyLanguage.Model;
using ToyLanguage.Model.Expression;
using ToyLanguage.Model.Statement;
using ToyLanguage.Model.Statement.FileTablePack;
using ToyLanguage.Model.Statement.HeapPack;
using ToyLanguage.Model.Type;
using ToyLanguage.Model.Value;
using ToyLanguage.RepositoryPack;
using ToyLanguage.View;
using ToyLanguage.View.CommandPack;
using Type = ToyLanguage.Model.Type.Type;

namespace ToyLanguage
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Statement s = new CompStatement(new VarDeclStatement("v",new IntType()), 
                new CompStatement(new AssignStatement("v",new ValueExpression(new IntValue(2))), 
                    new PrintStatement(new VariableExpression("v"))));
            List<ProgramState> l = new List<ProgramState>();
            l.Add(new ProgramState(new Stack<Statement>(),new ConcurrentDictionary<string, Value>(),new List<Value>(),s ));
            RepositoryInterface r = new Repository(l);
            ControllerInterface c = new Controller(r);
            
            Statement s2 = ex1();
            List<ProgramState> l1 = new List<ProgramState>();
            l1.Add(new ProgramState(new Stack<Statement>(),new ConcurrentDictionary<string, Value>(),new List<Value>(),s2 ));
            RepositoryInterface r1 = new Repository(l1);
            ControllerInterface c1 = new Controller(r1);
            
            
            Statement s3 = ex2();
            List<ProgramState> l2 = new List<ProgramState>();
            l2.Add(new ProgramState(new Stack<Statement>(),new ConcurrentDictionary<string, Value>(),new List<Value>(),s3 ));
            RepositoryInterface r2 = new Repository(l2);
            ControllerInterface c2 = new Controller(r2);
            
            Statement s4 = ex4();
            List<ProgramState> l4 = new List<ProgramState>();
            l4.Add(new ProgramState(new Stack<Statement>(),new ConcurrentDictionary<string, Value>(),new List<Value>(),s4 ));
            RepositoryInterface r4 = new Repository(l4);
            ControllerInterface c4 = new Controller(r4);
            
            Statement s5 = ex5();
            List<ProgramState> l5 = new List<ProgramState>();
            l5.Add(new ProgramState(new Stack<Statement>(),new ConcurrentDictionary<string, Value>(),new List<Value>(),s5 ));
            RepositoryInterface r5 = new Repository(l5);
            ControllerInterface c5 = new Controller(r5);
            
            Statement s6 = ex6();
            List<ProgramState> l6 = new List<ProgramState>();
            l6.Add(new ProgramState(new Stack<Statement>(),new ConcurrentDictionary<string, Value>(),new List<Value>(),s6 ));
            RepositoryInterface r6 = new Repository(l6);
            ControllerInterface c6 = new Controller(r6);
            
            TextMenu menu = new TextMenu(new ConcurrentDictionary<string, Command>());
            menu.addCommand(new ExitCommand("x","Exit"));
            menu.addCommand(new RunCommand("1",s.ToString(), c));
            menu.addCommand(new RunCommand("2",s2.ToString(),c1));
            menu.addCommand(new RunCommand("3",s3.ToString(),c2));
            menu.addCommand(new RunCommand("4",s4.ToString(),c4));
            menu.addCommand(new RunCommand("5",s5.ToString(),c5));
            menu.addCommand(new RunCommand("6",s6.ToString(),c6));
            
            menu.runTextMenu();
        }

        private static Statement ex1()
        {
            /*
            string varf;
            varf="test.in";
            openRFile(varf);
            int varc;
            readFile(varf,varc);print(varc);
            readFile(varf,varc);print(varc)
            closeRFile(varf) 
             */
            return new CompStatement(new VarDeclStatement("v",new StringType()), 
               new CompStatement(new AssignStatement("v",new ValueExpression(new StringValue("testfile1.in"))), 
                   new CompStatement(new VarDeclStatement("b",new IntType()), 
                       new CompStatement(new OpenReadFile(new VariableExpression("v"))
                           , new CompStatement(new ReadFile(new VariableExpression("v"),"b" ), 
                              new CompStatement(new PrintStatement(new VariableExpression("b")), 
                                 new CompStatement(new ReadFile(new VariableExpression("v"),"b" ), 
                                     new CompStatement(new PrintStatement(new VariableExpression("b")), new CloseFile(new VariableExpression("v")))) ) )))) );
        }

        private static Statement ex2()
        {
            /*
             int v;
             v="aa"
             */
            return new CompStatement(new VarDeclStatement("b",new IntType()),new AssignStatement("b",new ValueExpression(new StringValue("aa"))) );
        }

        private static Statement ex4()
        {
            return new IfStatement(new RelationalExpression(new ValueExpression(new IntValue(5)),new ValueExpression(new IntValue(4)),">"  ),new PrintStatement(new ValueExpression(new StringValue("greater"))),new NopStatement()  );
        }

        private static Statement ex5()
        {
            /*
             *  Ref int v;new(v,20);print(rH(v)); wH(v,30);print(rH(v)+5)
             */
            return new CompStatement(new VarDeclStatement("v",new ReferenceType(new IntType())), 
                new CompStatement(new NewStatement(new ValueExpression(new IntValue(20)), "v" ), 
                    new CompStatement(new PrintStatement(new ReadHeapExpr(new VariableExpression("v"))), 
                       new CompStatement(new WriteHeap("v",new ValueExpression(new IntValue(30))), 
                          new PrintStatement(new ArithmeticExpression(new ReadHeapExpr(new VariableExpression("v")),new ValueExpression(new IntValue(5)),"+"  )) ) )));
        }


        private static Statement ex6()
        {
            /*
             *  int v; v=4; (while (v>0) print(v);v=v-1);print(v)
             */
            return new CompStatement(new VarDeclStatement("v",new IntType()), 
                new CompStatement(new AssignStatement("v",new ValueExpression(new IntValue(4))), 
                   new WhileStatement(new RelationalExpression(new VariableExpression("v"),new ValueExpression(new IntValue(0)),">"  ), 
                       new CompStatement(new PrintStatement(new VariableExpression("v")), 
                           new AssignStatement("v",new ArithmeticExpression(new VariableExpression("v"),new ValueExpression(new IntValue(1)),"-"  )))) ));
        }
    }
}