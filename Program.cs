using System;
using System.Collections.Generic; // para utilziar lista

namespace tp1
{
    // actividad 1.
    // Implementar la interface implica solo lo siguiente. Si dijera implementar los metodos de la interface se referiria a hacerlo en las clases que pertenecen a esa interface
    public interface Comparable // hacer la interface publica permite usarla en cualquier namespace.
    {
        bool sosIgual(Comparable c); //toda interface se asume public. Esta bien sin especificar
        bool sosMenor(Comparable c);
        bool sosMayor(Comparable c);
    }
    // actividad 2
    public class Numero : Comparable
    {
        private int valor;
        public Numero(int v)
        {
            valor = v;
        }
        public int getValor()
        {
            return valor;
        }
        public bool sosIgual(Comparable c) // no hace falta usar override
        {
            return this.valor == ((Numero)c).getValor(); // Es necesario castear el comparable a numero ya que comparable no tiene un metodo getValor
        }
        public bool sosMenor(Comparable c)
        {
            return this.valor < ((Numero)c).getValor(); // Es necesario castear el comparable a numero ya que comparable no tiene un metodo getValor
        }
        public bool sosMayor(Comparable c)
        {
            return this.valor > ((Numero)c).getValor();
        }
        public override string ToString() // el metodo ToString existe en un metodo de object que aplica a todos los objetos y por eso esnecesario sobreescribirlo
        {
            return valor.ToString();
        }
    }
    //actividad 3
    public interface Coleccionable
    {
        int cuantos();
        Comparable minimo();
        Comparable maximo();
        void agregar(Comparable c);
        bool contiene(Comparable c);
    }
    //actividad 4
    public class Pila : Coleccionable
    {
        private List<Comparable> elementos;

        public Pila()
        {
            elementos = new List<Comparable>();
        }
        public void push(Comparable c)
        {
            elementos.Add(c);
        }
        public Comparable pop()
        {
            Comparable retorno = elementos[elementos.Count - 1];
            elementos.RemoveAt(elementos.Count - 1);
            return retorno;
        }
        public int cuantos()
        {
            return elementos.Count;
        }
        public Comparable minimo()
        {
            Comparable menor = elementos[0];
            for (int i = 1; i < elementos.Count; i++)
            {
                if (elementos[i].sosMenor(menor))
                {
                    menor = elementos[i];
                }
            }
            return menor;
        }
        public Comparable maximo()
        {
            Comparable mayor = elementos[0];
            for (int i = 1; i < elementos.Count; i++)
            {
                if (elementos[i].sosMayor(mayor))
                {
                    mayor = elementos[i];
                }
            }
            return mayor;
        }
        public void agregar(Comparable c)
        {
            elementos.Add(c);
        }
        public bool contiene(Comparable c)
        {
            for (int i = 0; i < elementos.Count; i++)
            {
                if (c.sosIgual(elementos[i])) // si aca usara c=elementos[i] me daria falso aunque los valores que quiero comparar son iguales, esto es pq == comapara posiciones de mempria, si las pos de memoria son distintas entonces da false
                {
                    return true;
                }
            }
            return false;
        }
    }
    public class Cola : Coleccionable
    {
        private List<Comparable> elementos;

        public Cola()
        {
            elementos = new List<Comparable>();
        }
        public void push(Comparable c)
        {
            elementos.Add(c);
        }
        public Comparable pop()
        {
            Comparable retorno = elementos[0];
            elementos.RemoveAt(0);
            return retorno;
        }
        public int cuantos()
        {
            return elementos.Count;
        }
        public Comparable minimo()
        {
            Comparable menor = elementos[0];
            for (int i = 1; i < elementos.Count; i++)
            {
                if (elementos[i].sosMenor(menor))
                {
                    menor = elementos[i];
                }
            }
            return menor;
        }
        public Comparable maximo()
        {
            Comparable mayor = elementos[0];
            for (int i = 1; i < elementos.Count; i++)
            {
                if (elementos[i].sosMayor(mayor))
                {
                    mayor = elementos[i];
                }
            }
            return mayor;
        }
        public void agregar(Comparable c)
        {
            elementos.Add(c);
        }
        public bool contiene(Comparable c)
        {
            for (int i = 0; i < elementos.Count; i++)
            {
                if (c.sosIgual(elementos[i])) // si aca usara c=elementos[i] me daria falso aunque los valores que quiero comparar son iguales, esto es pq == comapara posiciones de mempria, si las pos de memoria son distintas entonces da false
                {
                    return true;
                }
            }
            return false;
        }
    }
    // actividad 8
    public class ColeccionMultiple : Coleccionable
    {
        private Pila pila;//va privado???
        private Cola cola;//va privado???
        public ColeccionMultiple(Pila p, Cola c)
        {
            pila = p;
            cola = c;
        }
        public int cuantos()
        {
            return pila.cuantos() + cola.cuantos();
        }
        public Comparable minimo()
        {
            Comparable p = pila.minimo();
            Comparable c = cola.minimo();
            if (p.sosMenor(c))
            {
                return p;
            }
            return c;
        }
        public Comparable maximo()
        {
            Comparable p = pila.maximo();
            Comparable c = cola.maximo();
            if (p.sosMayor(c))
            {
                return p;
            }
            return c;
        }
        public void agregar(Comparable d) { }
        public bool contiene(Comparable d)
        {
            return pila.contiene(d) || cola.contiene(d);
        }
    }
    public class Persona : Comparable
    {
        private string nombre;
        private int dni;
        public Persona(string n, int d)
        {
            nombre = n;
            dni = d;
        }
        public string getNombre()
        {
            return nombre;
        }
        public int getDNI()
        {
            return dni;
        }
        public virtual bool sosIgual(Comparable c) // no hace falta usar override
        {
            return this.dni == ((Persona)c).getDNI(); // Es necesario castear el comparable a numero ya que comparable no tiene un metodo getValor
        }
        public virtual bool sosMenor(Comparable c)
        {
            return this.dni < ((Persona)c).getDNI(); // Es necesario castear el comparable a numero ya que comparable no tiene un metodo getValor
        }
        public virtual bool sosMayor(Comparable c)
        {
            return this.dni > ((Persona)c).getDNI();
        }
        public override string ToString() // el metodo ToString existe en un metodo de object que aplica a todos los objetos y por eso esnecesario sobreescribirlo
        {
            return dni.ToString();
        }
    }
    // actividad 15
    public class Alumno : Persona
    {
        private int legajo;
        private float promedio;
        public Alumno(string n, int d, int l, float p) : base(n, d)
        {
            legajo = l;
            promedio = p;
        }
        public int getLegajo()
        {
            return legajo;
        }
        public float getPromedio()
        {
            return promedio;
        }
        public override bool sosIgual(Comparable c) // no hace falta usar override
        {
            if (Program.CompararPor == "promedio")
            {
                return this.promedio == ((Alumno)c).getPromedio();
            }
            else
            {
                return this.legajo == ((Alumno)c).getLegajo();
            }
        }
        public override bool sosMenor(Comparable c)
        {
            if (Program.CompararPor == "promedio")
            {
                return this.promedio < ((Alumno)c).getPromedio();
            }
            else
            {
                return this.legajo < ((Alumno)c).getLegajo();
            }
        }
        public override bool sosMayor(Comparable c)
        {
            if (Program.CompararPor == "promedio")
            {
                return this.promedio > ((Alumno)c).getPromedio();
            }
            else
            {
                return this.legajo > ((Alumno)c).getLegajo();
            }
        }
        public override string ToString() // el metodo ToString existe en un metodo de object que aplica a todos los objetos y por eso esnecesario sobreescribirlo
        {
            if (Program.CompararPor == "promedio")
            {
                return promedio.ToString();
            }
            else
            {
                return legajo.ToString();
            }
        }
    }
    class Program
    {
        private static string compararPor = "promedio";
        public static string CompararPor
        {
            get { return compararPor; }
            set { compararPor = value; }
        }
        // actividad 5
        // me pide implementar una funcion. hay que hacerlo en alguna clase que no corresponda a las creadas para los ejercicios anteriores. puedo usar la clase Program o crear un clase Test de cualquier nombre.
        private static Random rnd = new Random();
        public static string nombreAleatorio()
        {
            int longitud=rnd.Next(4,11);
            string nombre="";
            for (int i=0;longitud>i;i++)
            {
                nombre+=(char)rnd.Next(97,123);
            }
            return nombre;
        }
        public static void llenar(Coleccionable d)
        {
            for (int i = 0; i < 20; i++)
            {
                d.agregar(new Numero(rnd.Next(1, 100)));
            }
        }
        // actividad 6 y 13
        public static void informar(Coleccionable d)
        {
            Console.WriteLine(d.cuantos());
            Console.WriteLine(d.minimo());
            Comparable max= d.maximo();
            Console.WriteLine(max);
            Type tipo = max.GetType();
            Comparable comp = null;
            if (tipo == typeof(Numero))
            {
                comp = new Numero(int.Parse(Console.ReadLine()));
            }
            if (tipo == typeof(Persona))
            {
                Console.WriteLine("Ingresar dni");
                comp = new Persona(nombreAleatorio(), int.Parse(Console.ReadLine()));
            }
            if (tipo == typeof(Alumno))
            {
                Console.WriteLine("Ingresar legajo");
                int legajoTeclado = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingresar promedio");
                float promedioTeclado =float.Parse(Console.ReadLine());
                Console.WriteLine(promedioTeclado);
                comp = new Alumno(nombreAleatorio(), rnd.Next(0,45000000), legajoTeclado, promedioTeclado);
            }
            if (d.contiene(comp))
            {
                Console.WriteLine("El elemento leído está en la colección");
            }
            else
            {
                Console.WriteLine("El elemento leído no está en la colección");
            }
        }
        // actividad 12
        public static void llenarPersonas(Coleccionable c)
        {
            for (int i = 0; i < 20; i++)
            {
                Comparable personaAzar = new Persona(nombreAleatorio(), rnd.Next(10000000, 45000000));//cambiar!!!
                c.agregar(personaAzar);
            }
        }
        public static void llenarAlumnos(Coleccionable c)
        {
            for (int i = 0; i < 20; i++)
            {
                Comparable alumnoAzar = new Alumno(nombreAleatorio(), rnd.Next(10000000, 45000000), rnd.Next(1, 1000000), (float)(rnd.Next(0, 1001) / 100.0));//cambiar!!!
                c.agregar(alumnoAzar);
            }
        }
        static void Main(string[] args)
        {
            /*// test actividad 2
            Comparable n1,n2,n3,n4;
            n1= new Numero(5);
            n2= new Numero(5);
            n3= new Numero(8);
            n4= new Numero(3);

            Console.WriteLine(n1.sosIgual(n2));
            Console.WriteLine(n1.sosMenor(n3));
            Console.WriteLine(n1.sosMayor(n4));

            //test activiadad 4
            Coleccionable col= new Pila();
            col.agregar(n1);
            col.agregar(n2);
            col.agregar(n3);

            Console.WriteLine(col.minimo()); // aparentemente la funcion WriteLine aplica el metodo Tostring a cualquier objeto que tome como parametro y por eso no es necesario hacer explicito que aplique el Tostring que yo implemente con override en la clase Numero
            Console.WriteLine(col.maximo());
            Console.WriteLine(col.contiene(n2));
            // test actividad 6
            informar(col);*/
            
            //actividad 7
            /*
            Pila pila1 = new Pila();
            Cola cola1 = new Cola();
            llenar(pila1);
            llenar(cola1);
            informar(pila1);
            informar(cola1);
            */
            /*
            // actividad 9
            Console.WriteLine("Actividad 9");
            Pila pila2= new Pila();
            Cola cola2= new Cola();
            ColeccionMultiple multiple = new ColeccionMultiple(pila2, cola2);//evidentemente esto pasa la posicion de memoria de las dos varias pq si en un futuro las modifico tambien se modifican en multiple
            llenar(pila2);
            llenar(cola2);
            informar(pila2);
            informar(cola2);
            informar(multiple);
            // activida 10. No modifique nada
            */
            /*
            // actividad 13
            Pila pila3= new Pila();
            Cola cola3= new Cola();
            ColeccionMultiple multiple2= new ColeccionMultiple(pila3, cola3);
            llenarPersonas(pila3);
            llenarPersonas(cola3);
            informar(multiple2);
            */
            // actividad 17

            Pila pila4 = new Pila();
            Cola cola4 = new Cola();
            ColeccionMultiple multiple4 = new ColeccionMultiple(pila4, cola4);
            llenarAlumnos(pila4);
            llenarAlumnos(cola4);
            Console.WriteLine("tipo de comparacion promedio/legajo");
            Program.CompararPor = Console.ReadLine();
            informar(multiple4);
            Console.ReadKey();
        }
    }
}
// act 17.No hace falta declarar explicatamente que alumno tiene que implementar la interface comparable. comparo en min max alumnos por promedio pq me parecio la comparacion mas util de entre las opciones. Para eso inplemente los metodos de comparable con override y en persona los puse como virtual. 
// act 18. agregue a Program el dato miembro estatico compararPor. se ingresa por teclado el valor de compararPor. los metodos de la interface Comparable implementados en Alumno comparar por promedio o legajo segun el valor de compararPor. To string tambien devuelve promedio o legajo segun compararPor
// act 11. "Compare las personas por dni o por nombre, según prefiera." se refiere a implementar una de las dos o que el usuario del programa elije
// en la funcion informar tengo que agregar una persona O alumno por teclado. tendria que ingresar ek nombre y despues el dni o que genere aleatoriamente el nombre y solo ingresar el dni por teclado o hago constructures que solo requieran los datos necesarios para coparar?