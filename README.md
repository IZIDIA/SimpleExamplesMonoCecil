# SimpleExamplesMonoCecil
Simple examples of how the compiler works with Mono Cecil.

In this example, I have implemented the below methods with Mono Cecil. The result is dll file.

Methods on C#:
public static class A_sbyte_остаток_от_деления { public static sbyte gg(sbyte a, sbyte b) { return (sbyte)(a % b); } }

public static class A_short_больше_или_равно { public static bool gg(short a, short b) { return a >= b; } }

public static class A_long_меньше_или_равно { public static bool gg(long a, long b) { return a <= b; } }

public static class A_ulong_checked_вычитание { public static ulong gg(ulong a, ulong b) { return checked(a - b); } }

public static class A_decimal_деление { public static decimal gg(decimal a, decimal b) { return a / b; } }

public static class GcdModReturn { public static int Go(int a, int b) { while (true) { if (b == 0) { return a; } int r = a % b; a = b; b = r; } } }
