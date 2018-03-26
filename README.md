# **Grupa10-Logi~~crack~~**
![Logicrack](logicrack_logo.png)

## Članovi tima:
*Somun Kenan - Šehić Mirza*

# Tema: GoFly (Rezervacija leta je najlakša uz GoFly!)

## Opis teme
Dobro su nam poznate svakodnevne gužve na aerodromima pri rezervaciji i kupovini karata. Naš sistem jednostavnim interfejsom rješava ove probleme za korisnika u samo nekoliko klikova.

Rezervacija karata nikada nije bila lakša! Odaberite pojedinosti poput odredišta, datuma odlaska i dolaska, broja saputnika, te vrstu klase i provjerite sve dostupne letove sa Vama najbližeg aerodroma.
Ukoliko želite saznati detalje o nekom letu iste možete dobiti jednostavnim unosom broja leta u aplikaciji za što nije potrebna registracija.
 
Menadžment letova, statistički podaci te upravljanje zahtjevima jednostavno je kroz interfejs za admina (vlasnika) kompanije.

## Procesi
### Menadžment korisnika
U aplikaciji postoje 3 različite privilegije pristupa sistemu. Gosti mogu provjeriti dostupnost leta za odabrane zahtjeve, kao i provjeriti detalje leta za neki let (pomoću jedinstvenog broja leta). Registrovanim korisnicima se omogućuje rezervisanje letova, uređivanje profila, slanje zahtjeva za eventualno otkazivanje leta te ostavljanje dojma nakon leta. Menadžer (vlasnik) posjeduje mogućnosti za unos ponude letova, odobravanje zahtjeva za otkazivanje leta, odgađanje letova kao i uvid u statistiku. 

### Rezervacija leta
Rezervacija leta je omogućena samo registrovanim korisnicima što zahtjeva plaćanje rezervacije kreditnom karticom.

### Obavijesti o letovima
Pri prvoj sljedećoj prijavi na sistem korisniku se ispisuju obavijesti vezane za njegove rezervisane letove. 

### Menadžment letova
Ovaj proces nudi unos ponude letova, te sistem za odobravanje zahtjeva za otkazivanjem leta od strane korisnika. U slučaju vremenskih neprilika ili nekih drugih nepogoda, vlasnik također može jednostavnim klikom odgoditi let, za što će korisnici biti obavješteni procesom 'Obavijesti o letovima'. 
	
## Funkcionalnosti
* Mogućnost prijave u sistem sa različitim privilegijama (administrator, gost korisnik, registrovani korisnik)
* Funkcionalnosti za gost korisnike:
	- Mogućnost pretrage dostupnih letova za odabrane zahtjeve
	- Mogućnost provjere detalja leta pomoću broja leta
* Funkcionalnosti za registrovane korisnike:
	- Mogućnost rezervacije leta i plaćanja leta kreditnom karticom
	- Mogućnost uređivanja ličnog profila 
	- Mogućnost uvida u sve rezervisane letove uz opciju da se pošalje zahtjev za otkazivanjem leta
	- Mogućnost ocjenjivanja kvalitete usluge ostavljanjem komentara, te praćenja oficijalne stranice kompanije na društvenim mrežama
* Funkcionalnosti za administratora (vlasnika) kompanije:
	- Mogućnost unosa ponude letova
	- Mogućnost odgode letova uz obavještavanje putnika leta 
	- Mogućnost upravljanja zahtjevima (otkazivanje leta, korisničke privilegije)
	- Mogućnost uvida u statističke podatke kompanije

## Akteri
- _Gost korisnik_ - osoba koja ima mogućnost pretrage dostupnosti letova za odabrane zahtjeve, te provjere detalja nekog leta pomoću unosa jedinstvenog broja leta
- _Registrovani korisnik_ - osoba koja ima mogućnost rezervacije leta, uređivanja profila, ostavljanja dojma o kvaliteti usluge, te slanje zahtjeva za otkazivanje leta 
- _Administrator_ - unosi ponudu letova, upravlja dobijenim zahtjevima, te nadgleda detaljnu statistiku kompanije