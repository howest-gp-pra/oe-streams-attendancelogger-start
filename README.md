# oe-attendancelogger-start
## Opzet
Deze oefening leest een bestand met de namen van studenten lijn per lijn in.
Vervolgens worden de ingelezen studenten toegevoegd aan een listbox.

Een gebruiker (leraar) kan vervolgens aanduiden welke studenten uit de lijst aanwezig zijn in de les
en een lijst van aanwezige studenten opslaan.

Een bestand wordt uitgelezen en vult `lstSubsribedStudents`. Vervolgens kan de leraar op twee knoppen klikken
om ingeschreven studenten toe te voegen aan of verwijderen uit `lstPresentStudents`.

Bij het klikken op `btnSave` worden de studenten die in `lstPresentStudents` staan weggeschreven naar .txt-bestand op
een locatie die door de gebruiker gekozen kan worden.

## Technische uitwerking
Maak in een aparte class library twee service klasses, `ReadService` en `WriteService`.
**Er wordt een andere aanpak gekozen dan het cursusvoorbeeld.**

### ReadService
Deze klasse is verantwoordelijk voor het uitlezen van een bestand op een **vaste locatie**.
Het bestand dat uitgelezen moet worden vind je in de folder van je solution onder *Pra.Streams.AttendanceLogger.Wpf* > *assets* > *students.txt*.
De locatie van dit bestand mag **niet** veranderen! Denk dus goed na over welk (relatief) pad je moet schrijven!

Tip: bestudeer het bestand ook eens. Merk op dat er per lijn een student staat.

Voorzie de klasse van 1 methode: `public List<string> ReadLines(...)` en lees het bovengenoemde bestand lijn per lijn uit.
Dit kan je doen a.d.h.v. deze code:
```
string currentLine;
List<string> lines = new List<string>();

using (StreamReader file = new StreamReader(...))
{
    currentLine = file.ReadLine();

    while(currentLine != null)
    {
        lines.Add(currentLine);
        currentLine = file.ReadLine();
    }
}
```
In de code hierboven werd bewust een deel weggelaten!

Gebruik de ReadService in de code behind en voeg de namen van de studenten toe aan `lstSubscribedStudents`.
Denk eraan dat sommige studenten accenttekens in hun naam hebben. Zorg ervoor dat de tekst juist ingelezen wordt.

**Tip:** zoek eerst even uit met welke karakterset het tekstbestand door ons werd opgeslagen.

Deze methode gooit exceptions als er iets misgaat met het inlezen van het bestand.
Zorg dat deze goed afgehandeld worden wanneer je de methode oproept!

### WriteService
Ook de `WriteService` heeft slechts 1 methode: `void WriteToFile(...)`.
Deze schrijft ontvangen data onmiddellijk weg naar een door de gebruiker gekozen locatie.
Ook deze methode kan exceptions gooien, wanneer er iets misloopt met het wegschrijven van het bestand.
Zorg ervoor dat deze errors goed afgehandeld worden wanneer je de methode aanroept.

### Save file dialog
Wanneer de gebruiker de lijst met aanwezige studenten wil opslaan, wordt er een dialoogvenster getoond om de locatie en naam van het bestand
te kiezen. Voorzie een default naam voor het bestand, bv. `"present-students-dd-mm-yyyy.txt"` waarbij `dd-mm-yyyy` vervangen wordt door
de datum van vandaag (bv. `5-11-2020`).

### Code behind
Voorzie propere code die gebruik maakt van de service klasses.
De gebruiker wordt op de hoogte gesteld van fouten.
Bij belangrijke fouten (bv. het niet kunnen uitlezen van de source file) worden alle knoppen in de applicatie gedisabled.

### Extra's
- Sorteer de beide lijsten van studentennamen.
- Zoals steeds zorg je er uiteraard minimaal voor dat je applicatie nooit crasht wanneer je op een knop klikt. Als extra kan je ervoor zorgen
  dat een knop enkel actief is wanneer het nuttig is om erop te kunnen klikken. Bijvoorbeeld:
  - Student toevoegen aan de lijst met aanwezig studenten kan alleen als er een student geselecteerd is.
  - Idem voor verwijderen van een aanwezige student uit de lijst.
  - Opslaan van aanwezige studenten kan alleen als er minstens 1 aanwezige student aangeduid is.

## Voorbeeld
![flow](Screens/flow.gif)





