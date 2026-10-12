using KatalogProduktów;

Console.OutputEncoding = System.Text.Encoding.UTF8;

string[] nazwy = { "Procesor", "Pamięć RAM", "Dysk SSD", "Zasilacz" };
double[] ceny = { 899.00, 249.50, 379.00, 189.99 };

//stwórz nowy obiekt procesor według definicji klasy Produkt
Produkt procesor = new Produkt("AMD Ryzen",899.00,"Podzespoły",10);
Produkt ram = new Produkt("Pamięć RAM", 249.50, "Podzespoły", 20);
//Produkt ssd = new Produkt("Dysk SSD", -379.00, "Podzespoły", -15); //celowo źle do testów
Produkt ssd = new Produkt("Dysk SSD", 379.00, "Podzespoły", 15);
Produkt zasilacz = new Produkt("Zasilacz", 189.99, "Podzespoły", 5);


//tworzymy tablicę produktów
Produkt[] produkty = { procesor, ram, ssd, zasilacz };
//pusta tablica na 10 produktów
Produkt[] produkty2 = new Produkt[10];
//jeśli chcemy listę to:
//najpierw słowo List potem w nawiasach ostrych typ danych jaki chcemy przechowywać
// potem nazwa zmiennej i przypisujemy konstruktorem nową pustą listę
List<Produkt> listaProduktow = new List<Produkt>();
//mając listę dodajemy do niej produkty metodą Add
listaProduktow.Add(procesor);
listaProduktow.Add(ram);
listaProduktow.Add(ssd);
listaProduktow.Add(zasilacz);

//tu możemy wymienić sobię tablicę na listę i odwrotnie i dalej będzie działać
foreach (Produkt produkt in listaProduktow)
{
    produkt.WypiszProdukt();
}


double suma = 0;
int licznik = 0;
//dla tablicy przechodziliśmy "ręcznie" po indeksach i sprawdzaliśmy cenę
for (int i = 0; i < nazwy.Length; i++)
{
    // Do sumy trafiają tylko produkty droższe niż 200 zł
    if (ceny[i] > 200)
    {
        suma = suma + ceny[i];
        licznik++;
    }
}
//dla listy możemy użyć LINQ do zsumowania całości
double sumaListy = listaProduktow.Sum(p => p.Cena); //czytamy jako dla każdego produktu sumuj jego pole Cena
//albo możemy odfiltrować LINQ produkty droższe niż 200 zł i zsumować tylko te droższe
List<Produkt> drogieProdukty = listaProduktow.Where(p => p.Cena > 200).ToList(); //zwraca listę produktów droższych niż 200 zł
//możemy połaczyć obie metody (tzw. chainowanie metod) i od razu zsumować ceny produktów droższych niż 200 zł
double sumaDrogichProduktow = listaProduktow.Where(p => p.Cena > 200).Sum(p => p.Cena); 


// Uwaga: przy pustym liczniku byłoby dzielenie przez zero
double srednia = suma / licznik;
//Console.WriteLine($"Ilość produktów w bazie: {nazwy.Length}");
//Console.WriteLine($"Średnia cena: {srednia:F2} zł z {licznik} produktów");

//srednia dla listy
double sredniaListy = listaProduktow.Average(p => p.Cena); //zwraca średnią cenę wszystkich produktów w liście

//wywołanie metody statycznej klasy Produkt, która liczy sumę wartości magazynu dla wszystkich produktów w tablicy
//wywołujemy poprzez nazwę klasy -> kropka -> nazwa metody statycznej -> w nawiasach podajemy tablicę produktów
double wartoscMagazynu = Produkt.ObliczWartoscMagazynu(produkty);
Console.WriteLine($"Suma wartości magazynu dla wszystkich produktów: {wartoscMagazynu:f2} zł");

double wartoscListy = Produkt.ObliczWartoscMagazynu(listaProduktow); 

Console.WriteLine(procesor.ToString());

Produkt p = Produkt.ZnajdzPoNazwie(produkty, "Dysk SSD");
Console.WriteLine($"Znaleziono produkt: {p.Nazwa}, cena: {p.Cena} zł, ilość: {p.Ilosc}");