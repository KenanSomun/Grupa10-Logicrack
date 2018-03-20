# **Grupa10-Logi~~crack~~**

## Članovi tima:
*1. Fajić Amina*
*2. Somun Kenan*
*3. Šehić Mirza*

## Opis teme
Dobro su nam poznate svakodnevne gužve na aerodromima pri rezervaciji i kupovini karata, naš sistem jednostavnim interfejsom rješava ove probleme za korisnika u samo nekoliko klikova.

Rezervacija karata nikada nije bila lakša! Odaberite pojedinosti poput odredišta, datuma odlaska i dolaska, broja saputnika, te vrstu kabine i provjerite sve dostupne letove sa Vama najbližeg aerodroma.

_Pregled statusa letova uz pojedinosti poput distance, eventualnog presjedanja i planiranog vremena trajanja je također podržan jednostavnim unosom broja leta._ (Treba li nam i ova funkcionalnost?)

Marketing za saradnike kompanije na prvoj stranici naše aplikacije je obezbjeđen te korisnik sa samo jednim klikom dobija potpune informacije o putnom osiguranju ili rezervisanju hotela na destinaciji odredišta. (Ovo bih također istakao kao samo jednu od mogućnosti - odgovor na pitanje zašto bi neko kupio naš sistem, ne bih detaljisao implementaciju jer nam nije to u interesu ovog projekta?)

## Procesi
### Registracija i prijava korisnika
Prilikom pokretanja aplikacije, korisnik može odabrati pojedinosti željenog leta te potom izvršiti rezervaciju. Rezervacija je omogućena samo za registrovane korisnike koji tom prilikom unose lične podatke. Posjedovanjem profila korisnik može da se prijavljuje na sistem te ima mogućnosti: uvida u rezervisane letove, njihovo eventualno otkazivanje kao i ostavljanje dojma kompaniji nakon obavljenog leta.

### Pregled dostupnih letova
Korisnici mogu provjeravati sve dostupne letove za željeni odabir pojedinosti, ali i provjeriti stanje leta (pomoću jedinstvenog broja leta). Rezervacija leta je omogućena samo za registrovane/prijavljene korisnike.

### Ažuriranje podataka o letovima
Naše rješenje automatski ažurira podatke o letovima nakon unosa letova, rezervacija, odlaska aviona sa aerodroma, kao i prihvaćenih zahtjeva za otkazivanje leta.

### Upravljanje avio-kompanijom (za vlasnika/menadžera)
Ovaj proces nudi unos ponude letova, te sistem za odobravanje zahtjeva za otkazivanjem leta od strane korisnika. U slučaju vremenskih neprilika ili nekih drugih nepogoda, vlasnik također može jednostavnim klikom odgoditi let te automatski poslati obavještenje korisnicima.
Statistike po više osnova su također dostupne pri prijavi u sistem sa privilegijom menadžera.

## Funkcionalnosti
- Mogućnost prijave u sistem sa različitim privilegijama (menadžer, korisnik - gost, korisnik - prijavljeni/registrovani)
- Mogućnost uređivanja ličnog profila 
- Mogućnost provjere dostupnih letova, te provjere stanja leta na osnovu trenutne lokacije (GPS)
- Mogućnost rezervacije i plaćanja leta (online), kao i uvida u sve rezervisane letove, ukupan broj letova i sl. (statistički)
- Mogućnost ažuriranja podataka o letovima, te obavještenja korisnika o bitnim obavjestima poput odgode leta i sl. (Notifikacija/SMS)
- Mogućnost ocjenjivanja kvalitete usluge ostavljanjem komentara, te 'like-ovanja' zvanične stranice na Facebook-u
- Mogućnost poziva za provjeru dostupnosti i stanja leta 
- Mogućnost upravljanja zaposlenim osobljem od strane menadžera

## Akteri
- Korisnik usluga - osoba koja ima mogućnost pregleda dostupnosti leta, te rezervacije leta (ukoliko je registrovani/prijavljeni korisnik)
- Uposlenik - osoba koja odgovara na pozive za informacije, te naplaćuje direktna plaćanja 
- Menadžer - ažurira ponudu letova, odobrava eventualne zahtjeve za otkazivanje leta od strane korisnika, nadgleda detaljnu statistiku glede kompanije, te upravlja zaposlenim osobljem













