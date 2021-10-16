using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LAB_2 {
	class Program {
		#region HelperMethods
		public static TypeDefinition MakeNewTypeDefenition(TypeReference typeReference, string className) => new TypeDefinition("", className,
				TypeAttributes.Public |
				TypeAttributes.AnsiClass |
				TypeAttributes.Abstract |
				TypeAttributes.Sealed |
				TypeAttributes.BeforeFieldInit,
				typeReference);
		public static MethodDefinition MakeNewMethodDefinition(TypeReference typeReference, string methodName) => new MethodDefinition(methodName,
				MethodAttributes.Public |
				MethodAttributes.HideBySig |
				MethodAttributes.Static,
				typeReference);
		public static void LaunchDllAndShowResults(System.Reflection.Assembly assembly, string typeName, string methodName, object a, object b) {
			var method = assembly.GetType(typeName).GetMethod(methodName);
			Console.WriteLine(method.Invoke(null, new object[] { a, b }));
			//Вместо Invoke можно использовать method.CreateDelegate
		}
		#endregion
		static List<InformationAboutMethod> allTasksMethodInfo = new List<InformationAboutMethod>();
		static void Main(string[] args) {
			var module = ModuleDefinition.CreateModule("example", ModuleKind.Dll);
			#region TaskOne
			{
				allTasksMethodInfo.Add(new InformationAboutMethod { ClassName = "A_sbyte_остаток_от_деления", MethodName = "gg", A = (sbyte)13, B = (sbyte)10 });
				var program = MakeNewTypeDefenition(module.TypeSystem.Object, allTasksMethodInfo.Last().ClassName);
				module.Types.Add(program);
				var gg = MakeNewMethodDefinition(module.TypeSystem.SByte, allTasksMethodInfo.Last().MethodName);
				program.Methods.Add(gg);
				var a = new ParameterDefinition("a", ParameterAttributes.None, module.TypeSystem.SByte);
				gg.Parameters.Add(a);
				var b = new ParameterDefinition("b", ParameterAttributes.None, module.TypeSystem.SByte);
				gg.Parameters.Add(b);
				var cil = gg.Body.GetILProcessor();
				cil.Emit(OpCodes.Ldarg, a);
				cil.Emit(OpCodes.Ldarg, b);
				cil.Emit(OpCodes.Rem);
				cil.Emit(OpCodes.Conv_I1);
				cil.Emit(OpCodes.Ret);
			}
			#endregion
			#region TaskTwo
			{
				allTasksMethodInfo.Add(new InformationAboutMethod { ClassName = "A_short_больше_или_равно", MethodName = "gg", A = (short)13, B = (short)10 });
				var program = MakeNewTypeDefenition(module.TypeSystem.Object, allTasksMethodInfo.Last().ClassName);
				module.Types.Add(program);
				var gg = MakeNewMethodDefinition(module.TypeSystem.Boolean, allTasksMethodInfo.Last().MethodName);
				program.Methods.Add(gg);
				var a = new ParameterDefinition("a", ParameterAttributes.None, module.TypeSystem.Int16);
				gg.Parameters.Add(a);
				var b = new ParameterDefinition("b", ParameterAttributes.None, module.TypeSystem.Int16);
				gg.Parameters.Add(b);
				var cil = gg.Body.GetILProcessor();
				cil.Emit(OpCodes.Ldarg, a);
				cil.Emit(OpCodes.Ldarg, b);
				cil.Emit(OpCodes.Clt);
				cil.Emit(OpCodes.Ldc_I4, 0);
				cil.Emit(OpCodes.Ceq);
				cil.Emit(OpCodes.Ret);
			}
			#endregion
			#region TaskThree
			{
				allTasksMethodInfo.Add(new InformationAboutMethod { ClassName = "A_long_меньше_или_равно", MethodName = "gg", A = (long)13, B = (long)10 });
				var program = MakeNewTypeDefenition(module.TypeSystem.Object, allTasksMethodInfo.Last().ClassName);
				module.Types.Add(program);
				var gg = MakeNewMethodDefinition(module.TypeSystem.Boolean, allTasksMethodInfo.Last().MethodName);
				program.Methods.Add(gg);
				var a = new ParameterDefinition("a", ParameterAttributes.None, module.ImportReference(module.TypeSystem.Int64));
				gg.Parameters.Add(a);
				var b = new ParameterDefinition("b", ParameterAttributes.None, module.ImportReference(module.TypeSystem.Int64));
				gg.Parameters.Add(b);
				var cil = gg.Body.GetILProcessor();
				cil.Emit(OpCodes.Ldarg, a);
				cil.Emit(OpCodes.Ldarg, b);
				cil.Emit(OpCodes.Cgt);
				cil.Emit(OpCodes.Ldc_I4, 0);
				cil.Emit(OpCodes.Ceq);
				cil.Emit(OpCodes.Ret);
			}
			#endregion
			#region TaskFour
			{
				allTasksMethodInfo.Add(new InformationAboutMethod { ClassName = "A_ulong_checked_вычитание", MethodName = "gg", A = (ulong)13, B = (ulong)10 });
				var program = MakeNewTypeDefenition(module.TypeSystem.Object, allTasksMethodInfo.Last().ClassName);
				module.Types.Add(program);
				var gg = MakeNewMethodDefinition(module.TypeSystem.UInt64, allTasksMethodInfo.Last().MethodName);
				program.Methods.Add(gg);
				var a = new ParameterDefinition("a", ParameterAttributes.None, module.ImportReference(module.TypeSystem.UInt64));
				gg.Parameters.Add(a);
				var b = new ParameterDefinition("b", ParameterAttributes.None, module.ImportReference(module.TypeSystem.UInt64));
				gg.Parameters.Add(b);
				var cil = gg.Body.GetILProcessor();
				cil.Emit(OpCodes.Ldarg, a);
				cil.Emit(OpCodes.Ldarg, b);
				cil.Emit(OpCodes.Sub_Ovf_Un);
				cil.Emit(OpCodes.Ret);
			}
			#endregion
			#region TaskFive
			{
				allTasksMethodInfo.Add(new InformationAboutMethod { ClassName = "A_decimal_деление", MethodName = "gg", A = (decimal)13, B = (decimal)10 });
				var program = MakeNewTypeDefenition(module.TypeSystem.Object, allTasksMethodInfo.Last().ClassName);
				module.Types.Add(program);
				var gg = MakeNewMethodDefinition(module.ImportReference(typeof(decimal)), allTasksMethodInfo.Last().MethodName);
				program.Methods.Add(gg);
				var a = new ParameterDefinition("a", ParameterAttributes.None, module.ImportReference(typeof(decimal)));
				gg.Parameters.Add(a);
				var b = new ParameterDefinition("b", ParameterAttributes.None, module.ImportReference(typeof(decimal)));
				gg.Parameters.Add(b);
				var cil = gg.Body.GetILProcessor();
				cil.Emit(OpCodes.Ldarg, a);
				cil.Emit(OpCodes.Ldarg, b);
				var decimalDivide = typeof(decimal).GetMethod("op_Division", new Type[] { typeof(decimal), typeof(decimal) });
				cil.Emit(OpCodes.Call, module.ImportReference(decimalDivide));
				cil.Emit(OpCodes.Ret);
			}
			#endregion
			#region TaskSix
			{
				allTasksMethodInfo.Add(new InformationAboutMethod { ClassName = "GcdModReturn", MethodName = "Go", A = 13, B = 10 });
				var program = MakeNewTypeDefenition(module.TypeSystem.Object, allTasksMethodInfo.Last().ClassName);
				module.Types.Add(program);
				var gg = MakeNewMethodDefinition(module.TypeSystem.Int32, allTasksMethodInfo.Last().MethodName);
				program.Methods.Add(gg);
				var a = new ParameterDefinition("a", ParameterAttributes.None, module.ImportReference(module.TypeSystem.Int32));
				gg.Parameters.Add(a);
				var b = new ParameterDefinition("b", ParameterAttributes.None, module.ImportReference(module.TypeSystem.Int32));
				gg.Parameters.Add(b);
				var r = new VariableDefinition(module.TypeSystem.Int32);
				gg.Body.Variables.Add(r);
				var cil = gg.Body.GetILProcessor();
				var startWhile = Instruction.Create(OpCodes.Nop);
				var afterIf = Instruction.Create(OpCodes.Nop);
				var endWhile = Instruction.Create(OpCodes.Nop);
				cil.Append(startWhile);
				cil.Emit(OpCodes.Ldc_I4, 1);
				cil.Emit(OpCodes.Brfalse, endWhile);
				cil.Emit(OpCodes.Ldarg, b);
				cil.Emit(OpCodes.Ldc_I4, 0);
				cil.Emit(OpCodes.Ceq);
				cil.Emit(OpCodes.Brfalse, afterIf);
				cil.Emit(OpCodes.Ldarg, a);
				cil.Emit(OpCodes.Ret);
				cil.Append(afterIf);
				cil.Emit(OpCodes.Ldarg, a);
				cil.Emit(OpCodes.Ldarg, b);
				cil.Emit(OpCodes.Rem);
				cil.Emit(OpCodes.Stloc, r);
				cil.Emit(OpCodes.Ldarg, b);
				cil.Emit(OpCodes.Starg, a);
				cil.Emit(OpCodes.Ldloc, r);
				cil.Emit(OpCodes.Starg, b);
				cil.Emit(OpCodes.Br, startWhile);
				cil.Append(endWhile);
				cil.Emit(OpCodes.Ldc_I4, 0);
				cil.Emit(OpCodes.Ret);
			}
			#endregion
			module.Write("../Release/example.dll");
			#region ShowResults
			var count = 1;
			var assembly = System.Reflection.Assembly.LoadFrom("../Release/example.dll");
			foreach (InformationAboutMethod methodInfo in allTasksMethodInfo) {
				Console.WriteLine("Задание " + count + ":");
				switch (count) {
					case 1:
						Console.WriteLine(A_sbyte_остаток_от_деления.gg((sbyte)methodInfo.A, (sbyte)methodInfo.B));
						break;
					case 2:
						Console.WriteLine(A_short_больше_или_равно.gg((short)methodInfo.A, (short)methodInfo.B));
						break;
					case 3:
						Console.WriteLine(A_long_меньше_или_равно.gg((long)methodInfo.A, (long)methodInfo.B));
						break;
					case 4:
						Console.WriteLine(A_ulong_checked_вычитание.gg((ulong)methodInfo.A, (ulong)methodInfo.B));
						break;
					case 5:
						Console.WriteLine(A_decimal_деление.gg((decimal)methodInfo.A, (decimal)methodInfo.B));
						break;
					case 6:
						Console.WriteLine(GcdModReturn.Go((int)methodInfo.A, (int)methodInfo.B));
						break;
				}
				LaunchDllAndShowResults(assembly, methodInfo.ClassName, methodInfo.MethodName, methodInfo.A, methodInfo.B);
				count++;
			}
			#endregion
		}
	}
	public static class A_sbyte_остаток_от_деления {
		public static sbyte gg(sbyte a, sbyte b) {
			return (sbyte)(a % b);
		}
	}
	public static class A_short_больше_или_равно {
		public static bool gg(short a, short b) {
			return a >= b;
		}
	}
	public static class A_long_меньше_или_равно {
		public static bool gg(long a, long b) {
			return a <= b;
		}
	}
	public static class A_ulong_checked_вычитание {
		public static ulong gg(ulong a, ulong b) {
			return checked(a - b);
		}
	}
	public static class A_decimal_деление {
		public static decimal gg(decimal a, decimal b) {
			return a / b;
		}
	}
	public static class GcdModReturn {
		public static int Go(int a, int b) {
			while (true) {
				if (b == 0) {
					return a;
				}
				int r = a % b;
				a = b;
				b = r;
			}
		}
	}
}
