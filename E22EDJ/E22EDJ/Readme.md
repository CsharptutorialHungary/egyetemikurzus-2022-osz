# Game Time Tracker

## Telepítés

 - A projekt mysql adatbázist használ. A projekthez tartozik egy docker file, amiből buildeli, valamint elindítani lehet az adatbázist.
 - A migrációk futtatásához:

```Bash
dotnet ef database update
```

## Leírás

Az alakalmazás célja, hogy nyomon tudjuk követni az általunk játszott játékok állapotát, valamint a bennük eltöltött boldog perceket és órákat.

Az alkalamzás nyelve angol

## Követelmények

 - A projekt használ try-cath-et, hiba esetén ezt kiírjuk a konzolra
 - A projekt tartalmaz unit testeket
 - A projekt szerializáció helyett adatbázist használ
 - A projekt nem tartalmaz record class-ot
 - A projekt használ LINQ-t
 - A projekt használ generikus kollekciót
 - A projekt használ Task-ot
