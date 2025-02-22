using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;

int opcion;

do
{
    Console.Clear();
    Console.WriteLine("---------------Menu de Modulos---------------");
    Console.WriteLine("1. Calculadora Basica");
    Console.WriteLine("2. Validacion de Contrasenas");
    Console.WriteLine("3. Verificar Numero Primo");
    Console.WriteLine("4. Suma de Numeros Pares");
    Console.WriteLine("5. Conversion de Temperatura");
    Console.WriteLine("6. Contador de Vocales");
    Console.WriteLine("7. Calculo de Factorial");
    Console.WriteLine("8. Juego de Adivinanzas");
    Console.WriteLine("9. Paso por Referencia");
    Console.WriteLine("10. Tabla de Multiplicar");
    Console.WriteLine("0. Para salir");
    Console.WriteLine("\n---------------Elige una opcion---------------");


    if (int.TryParse(Console.ReadLine(), out opcion))
    {
        switch (opcion)
        {
            case 1:
                CalculadoraBasica();
                break;
            case 2:
                ValidacionDeContrasena();
                break;
            case 3:
                VerificacionDeNumeroPrimo();
                break;
            case 4:
                SumaDeNumerosPares();
                break;
            case 5:
                ConversionDeTemperatura();
                break;
            case 6:
                ContadorDeVocales();
                break;
            case 7:
                CalculodeFactorial();
                break;
            case 8:
                JuegodeAdivinanzas();
                break;
            case 9:
                PasosporReferencia();
                break;
            case 10:
                TabladeMultiplicar();
                break;
            case 0:
                Console.WriteLine("Saliendo del programa");
                break;
            default:
                Console.WriteLine("La opcion que acaba de proporcionar no es valida");
                break;
        }


    }
    else
    {
        Console.WriteLine("Ingresa un numero que sea valido.");
    }
    Console.WriteLine("\nPresiona cualquier tecla para continuar...");
    Console.ReadKey();
} while (opcion != 0);



static void CalculadoraBasica()
{
    Console.WriteLine("Ingresa el primer numero: ");
    if (!double.TryParse(Console.ReadLine(), out double numero1))
    {
        Console.WriteLine("El numero es invalido.");
        return;
    }
    Console.WriteLine("Ingresa el segundo numero: ");
    if (!double.TryParse(Console.ReadLine(), out double numero2))
    {
        Console.WriteLine("El numero es invalido.");
        return;
    }
    Console.WriteLine("Elige una operacion matematica: +,-,*,/");
    string operacion = Console.ReadLine() ?? string.Empty;

    double resultado = operacion switch
    {
        "+" => numero1 + numero2,
        "-" => numero1 - numero2,
        "*" => numero1 * numero2,
        "/" => numero2 != 0 ? numero1 / numero2 : double.NaN,
        _ => double.NaN
    };

    Console.WriteLine($"Resultado: {resultado}");
}


static void ValidacionDeContrasena()
{
    string contrasena;
    do
    {
        Console.WriteLine("Ingresa la contrasena: ");
        contrasena = Console.ReadLine() ?? string.Empty;
    } while (contrasena != "juandaniel2006");

    Console.WriteLine("El acceso ha sido concedido.");
}


static void VerificacionDeNumeroPrimo()
{
    Console.WriteLine("Ingrese un numero: ");
    if (int.TryParse(Console.ReadLine(), out int numero))
    {
        bool esPrimo = EsPrimo(numero);
        Console.WriteLine(esPrimo ? "El numero es Primo" : "El numero no es Primo");
    }
    else
    {
        Console.WriteLine("El Numero es Invalido.");
    }
}


static bool EsPrimo(int numero)
{
    if (numero < 2) return false;
    for (int i = 2; i * i <= numero; i++)
    {
        if (numero % i == 0) return false;
    }
    return true;
}


static void SumaDeNumerosPares()
{
    int suma = 0, numero;
    do
    {
        Console.WriteLine("Ingresa un numero (0 para finalizar): ");
        if (int.TryParse(Console.ReadLine(), out numero) && numero % 2 == 0)
        {
            suma += numero;
        }
    } while (numero != 0);

    Console.WriteLine($"La Suma de Pares es: {suma}");
}


static void ConversionDeTemperatura()
{
    Console.WriteLine("Ingresa la Temperatura: ");
    if (!double.TryParse(Console.ReadLine(), out double temperatura))
    {
        Console.WriteLine("El numero es invalido. ");
        return;
    }
    Console.WriteLine("Elige una opcion: Celsius a Fahrenheit o Fahrenheit a Celsius");
    string opcion = Console.ReadLine()?.ToUpper() ?? string.Empty;

    double resultado = opcion switch
    {

        "C" => (temperatura * 9 / 5) + 32,
        "F" => (temperatura - 32) * 9 / 5,
        _ => double.NaN
    };

    Console.WriteLine($"La Temperatura Convertida es: {resultado}");
}


static void ContadorDeVocales()
{
    Console.WriteLine("Ingresa una frase: ");
    string frase = Console.ReadLine()?.ToLower() ?? string.Empty;
    int contador = 0;
    foreach (char c in frase)
    {
        if ("aeiou".Contains(c)) contador++;
    }
    Console.WriteLine($"El numero de Vocales es: {contador}");
}


static void CalculodeFactorial()
{
    Console.Write("Ingresa un numero: ");
    if (int.TryParse(Console.ReadLine(), out int numero))
    {
        long factorial = 1;
        for (int i = 1; i <= numero; i++)
            factorial *= i;

        Console.WriteLine($"Factorial de {numero}: {factorial}");
    }
    else
    {
        Console.WriteLine("Numero invalido.");
    }
}


static void JuegodeAdivinanzas()
{
    Random rand = new Random();
    int numerosecreto = rand.Next(1, 101), intento;
    Console.WriteLine("Adivina el numero secreto (1-100)");

    do
    {
        Console.WriteLine("Ingresa un numero: ");
        if (int.TryParse(Console.ReadLine(), out intento))
        {
            if (intento < numerosecreto) Console.WriteLine("Demasiado bajo.");
            else if (intento > numerosecreto) Console.WriteLine("Demasiado alto.");
        }
    } while (intento != numerosecreto);

    Console.WriteLine("¡Adivinaste!");
}


static void PasosporReferencia()
{
    Console.Write("Ingresa el primer numero: ");
    if (!int.TryParse(Console.ReadLine(), out int numero1))
    {
        Console.WriteLine("Numero invalido.");
        return;
    }

    Console.Write("Ingresa el segundo numero: ");
    if (!int.TryParse(Console.ReadLine(), out int numero2))
    {
        Console.WriteLine("Numero invalido.");
        return;
    }

    Intercambiar(ref numero1, ref numero2);

    Console.WriteLine($"Valores intercambiados: {numero1}, {numero2}");
}

static void Intercambiar(ref int a, ref int b)
{
    int temp = a;
    a = b;
    b = temp;
}


static void TabladeMultiplicar()
{
    Console.Write("Ingresa un numero: ");
    if (int.TryParse(Console.ReadLine(), out int numero))
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{numero} x {i} = {numero * i}");
        }
    }
    else
    {
        Console.WriteLine("Numero invalido.");
    }
}
