# **Grupa10-Logi~~crack~~**
![Logicrack](logicrack_logo.png)

## Članovi tima:
*Somun Kenan - Šehić Mirza*

# Tema: GoFly (Rezervacija leta je najlakša uz GoFly!)

## Opis teme
Dobro su nam poznate svakodnevne gužve na aerodromima pri rezervaciji i kupovini karata. Naš sistem jednostavnim interfejsom rješava ove probleme za korisnika u samo nekoliko klikova.

Rezervacija karata nikada nije bila lakša! Odaberite pojedinosti poput odredišta, datuma odlaska i dolaska, broja saputnika, te vrstu klase i provjerite sve dostupne letove sa Vama najbližeg aerodroma.

_Pregled statusa letova uz pojedinosti poput distance, eventualnog presjedanja i planiranog vremena trajanja je također podržan jednostavnim unosom broja leta._ (Treba li nam i ova funkcionalnost?)

Marketing za saradnike kompanije na prvoj stranici naše aplikacije je obezbjeđen te korisnik sa samo jednim klikom dobija potpune informacije o putnom osiguranju ili rezervisanju hotela na destinaciji odredišta. (Ovo bih također istakao kao samo jednu od mogućnosti - odgovor na pitanje zašto bi neko kupio naš sistem, ne bih detaljisao implementaciju jer nam nije to u interesu ovog projekta?)

## Procesi
### Registracija i prijava korisnika
Prilikom pokretanja aplikacije, korisnik može odabrati pojedinosti željenog leta te potom izvršiti rezervaciju. Rezervacija je omogućena samo za registrovane korisnike koji tom prilikom unose lične podatke. Posjedovanjem profila korisnik može da se prijavljuje na sistem te ima mogućnosti: uvida u rezervisane letove, njihovo eventualno otkazivanje kao i uređivanje profila te ostavljanje dojma nakon obavljenog leta kroz jednostavan i pregledan korisnički interfejs.

### Pretraga dostupnih letova
Korisnici mogu provjeravati sve dostupne letove za željeni odabir pojedinosti, ali i provjeriti stanje leta (pomoću jedinstvenog broja leta). Rezervacija leta je omogućena samo za registrovane/prijavljene korisnike.

### Ažuriranje podataka o letovima
Naše rješenje automatski ažurira podatke o letovima nakon unosa letova, rezervacija, odlaska aviona sa aerodroma, kao i prihvaćenih zahtjeva za otkazivanje leta.

### Upravljanje avio-kompanijom (za menadžera/supervizora)
Ovaj proces nudi unos ponude letova, te sistem za odobravanje zahtjeva za otkazivanjem leta od strane korisnika. U slučaju vremenskih neprilika ili nekih drugih nepogoda, vlasnik također može jednostavnim klikom odgoditi let _te automatski poslati obavještenje korisnicima._
Statistike po više osnova su također dostupne pri prijavi u sistem sa privilegijom menadžera.

## Funkcionalnosti
- Mogućnost prijave u sistem sa različitim privilegijama (menadžer, korisnik - gost, korisnik - prijavljeni/registrovani)
- Mogućnost uređivanja ličnog profila 
- Mogućnost ocjenjivanja kvalitete usluge ostavljanjem komentara, te 'like-ovanja' zvanične stranice na Facebook-u
- Mogućnost uvida u sve rezervisane letove uz opciju da se pošalje zahtjev za otkazivanjem leta
- Mogućnost statističkih podataka o letovima korisnika
- Mogućnost pretrage dostupnih letova za odabrane pojedinosti (gdje se pomoću GPS-a tj. trenutne lokacije nude letovi sa korisniku najbližih aerodroma iz okruženja)
- Mogućnost rezervacije i plaćanja leta kreditnom karticom
- Mogućnost ažuriranja podataka o letovima, te obavještenja korisnika o bitnim obavjestima poput odgode leta i slično pri prvoj sljedećoj prijavi na sistem

## Akteri
- _Korisnik usluga_ - osoba koja ima mogućnost pretrage dostupnosti leta, te rezervacije leta (ukoliko je registrovani/prijavljeni korisnik)
- _Menadžer_ - ažurira ponudu letova, odobrava eventualne zahtjeve za otkazivanje leta od strane korisnika, te nadgleda detaljnu statistiku glede kompanije