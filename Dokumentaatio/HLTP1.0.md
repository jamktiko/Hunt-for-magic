# High Level Test Plan

Hunt for Magic

Tekijät: Niko Hokkanen

## Viitteet

| Viittaus            | Materiaali |
|---------------------|------------|
| Projektisuunnitelma | [linkki](https://github.com/jamktiko/Hunt-for-magic/blob/main/Dokumentaatio/Projektisuunnitelma1.0.md)     |
| GDD                 | [linkki](https://github.com/jamktiko/Hunt-for-magic/blob/main/Dokumentaatio/H4MDemo-GDD1.0.md)     |
| Coding guidelines   | [linkki](https://github.com/jamktiko/Hunt-for-magic/blob/main/Dokumentaatio/CodingGuidelines1.0.md)     |

## Intro

### Projekti lyhyesti
Projekti on ensimmäisestä persoonasta kuvattu 3D-peli PC:lle. Peliä käytetään näppäimistöllä ja hiirellä. Pelissä pelaaja toimii velhona, jonka tarkoituksena on estää nekromantikkoa kutsumasta suurta pahuutta maailmaan. Pelissä pelaajan ohjaama velho voi tutkia kenttiä ja taistella vihollisia vastaan erilaisilla loitsuilla, joita voidaan yhdistellä eri lopputulosten saamiseksi.

### Tarkoitus
Tämän dokumentin tarkoitus on kertoa, mitä pelissä pitää testata ja millä tavoin. Dokumentti sisältää kaiken käytännön tiedon projektissa tarvittavasta testauksesta.

##	Testistrategia

###	Testattavat yksiköt
*	Unity-executablet - Testataan pelin buildit, jotka ovat Unityn .exe -tiedostoja. Buildeista testataan:
    * Valikot pääpiirteittäin
    * Unity-Scenet testattavien ominaisuuksien osalta

###	Testitoimenpiteet
*	Tehdään testisuunnitelma ja asetetaan testikohtaiset hyväksymiskriteerit
*	Testataan peliä viikoittain peli- ja konseptitestauksen kautta
*	Kirjoitetaan testiraportti

###	Testattavat ominaisuudet
*	Kontrollien ja näppäinkomentojen yleinen toimivuus:
    * Pelihahmon liikkuminen
    * Näppäinkomennot tekevät halutut asiat
*	Mekaniikkojen ja interaktioiden toimivuus ja luotettavuus:
    * Taikojen ja niiden yhdistelmien toimivuus 
    * Vihollisten ja taistelujen toimivuus ja luotettavuus 
    * Käyttöliittymän toimivuus ja luotettavuus
*	Tarvittavan scenen / kenttien testaus toimivuuden ja suorituskyvyn kannalta

###	Ei testattavat ominaisuudet
*	Muut peliohjaimet
*	Muut ulkoiset komponentit

###	Lähestymistapa
*	Testataan manuaalisesti käyttämällä Unity-executableja
*	Ei käytetä testiautomaatiota ainakaan alussa, voidaan kuitenkin käyttää sitäkin tarvittaessa, jos aikaa jää

###	Hyväksymiskriteerit
*	Kontrollit, mekaniikat ja interaktiot todetaan toimivaksi, kun näppäimen painallus tms. tekee pelissä halutun asian.
*	Suorituskyky on riittävä, kun pelissä pystytään tekemään tarvittavat asiat ilman, että suorituskyky selvästi vaikuttaa pelikokemukseen ajallisesti
    * Pelin on pyörittävä vähintään 30 kuvaa sekunnissa 1080p -resoluutiolla testaajan tietokoneella

###	Testauksen keskeytys ja jatkaminen
*	Kriittisen bugin löytyessä testaus keskeytetään, ja jatketaan kun se on korjattu
*	Jos Unity-scene tai .exe kaatuu, testaus keskeytetään, ja jatketaan kun virhe on paikallistettu ja korjattu
*  Jos peli ei pyöri testaajan tietokoneella, testaus keskeytetään sen päätteen osalta

## Virheiden hallinta

### Virheiden raportointi
Testatut ja vahvistetut virheet raportoidaan sprinteittäin testiraporttiin, joka palautetaan Githubiin. Mukana pitää olla jonkinlainen selitys siitä, miten bugi/virhe laukeaa, sekä virheen vakavuusaste.

### Virheiden vakavuusasteet

* Kosmeettinen virhe - lievä graafinen bugi tai kirjoitusvirhe, ei vaikuta pelin toimintaan
* Matalan tason virhe - jokin asia pelissä toimii hieman eri lailla kuin pitäisi, voi vaikuttaa hieman pelin toimintaan
* Keskitason virhe - jokin asia pelissä ei toimi täysin suunnitellusti, vaikuttaa pelin toimintaan jonkin verran
* Korkean tason virhe - jokin olennainen asia pelissä ei toimi niin kuin pitäisi, vaikuttaa paljon pelin toimintaan
* Kriittinen virhe - peli kaatuu tai hyytyy paikalleen, voi vaikuttaa järjestelmän vakauteen

## Tuotokset
*	Hyväksymiskriteerit
*	Testisuunnitelma
*	Testiraportti
*  Konseptitestisuunnitelma
*  Konseptitestiraportti

## Ympäristö
*	Tietokone ja näyttö (vähintään 1080p)
*	Näppäimistö ja hiiri
*	Microsoft Windows 10
*	Unity 2019.4.18f1

## Velvollisuudet/vastuut
*	Testaustiimi on vastuussa siitä, että pelistä löytyvät virheet ja bugit kirjataan ylös korjaamista varten
*	Kehitystiimi on vastuussa mahdollisten virheiden ja bugien korjaamisesta, sekä buildien toimittamisesta testattavaksi

## Osaaminen ja sen hankinta
*	Tiimiltä vaaditaan perusosaaminen testauksesta teoriassa
*  Tiimi myös kehittää osaamistaan jatkuvasti, hankkien käytännön kokemusta testaamalla

## Aikataulut
*	Demo #1 valmis 18.3.2021
*	Demo #2 valmis 15.4.2021
*	Demo #3 valmis 12.5.2021
*	Komponentit testataan sitä mukaa kun ne ovat valmiita testattavaksi
*	Testidokumentit toimitetaan 24h sisällä testauksesta

## Riskit

| Riski            | Ratkaisu |
|---------------------|------------|
|Tiimissä on vain yksi testaaja - Testaajalle saattaa tulla liikaa töitä.|Annetaan testaajalle riittävästi aikaa testaamiseen|
|Motivaation puute - voi vaikuttaa tehokkuuteen|Yritetään pitää yllä hyvää ja motivoivaa ilmapiiriä|

## Oletukset ja riippuvuudet
*	Projekti suoritetaan projektisuunnitelman mukaisesti
*  Unity ja käyttöjärjestelmä toimivat asianmukaisesti
