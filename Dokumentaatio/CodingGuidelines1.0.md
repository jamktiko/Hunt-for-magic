# Coding Guidelines 
## Nimeämiskäytänteet 
Muuttujat, metodit ja luokat nimetään mahdollisimman kuvaavasti peliin liittyen. Luokat ja metodit kirjoitetaan isolla alkukirjaimella. Muuttujat nimetään alaviivalla ja pienellä alkukirjaimella niin, että seuraavat muuttujan nimessä mahdollisesti olevat termit kuitenkin kirjoitetaan isolla alkukirjaimella. Esimerkkejä: _player, _enemyCollider, _originalSpeed. Suojausmääreet ovat pakollisia. Jos esim. private-määreellä varustettu muuttuja halutaan näkyviin Unityssä, voidaan siihen lisätä kentän eteen [SerializeField] 

## Whitespacen käyttö 
Yleensä puolipisteen jälkeen tulee rivinvaihto eli Enter. Lauseiden väliin voi jättää tyhjän rivin, jos haluaa. If-lauseessa aaltosulkeet laitetaan seuraavan rivin alkuun, koodi laitetaan sitä seuraavalle riville, ja sulkeet laitetaan kiinni taas seuraavalta riviltä. Esim:  

 

                    if (health != null) 
                    { 
                        health.AddDamage(_damageAmount); 
                    } 

## Kommentointikäytänteet 

Ainakin metodit kannattaa kommentoida yleisesti, eli mitä kyseinen metodi tekee. Yksittäisiä muuttujia ei ole pakko kommentoida, mutta myös metodin osia voi kommentoida, jos sen kokee tarpeelliseksi. Myös kokonaisten luokkien kommentointi on vapaavalintaista, kunhan ainakin metodit kommentoi. Kommentointimerkintä kannattaa tehdä lisäämällä esim. metodin viereen kaksi vinoviivaa //. 

## Esimerkki 

    public class CoinScript : MonoBehaviour 
    { 
        [SerializeField] 
        private AudioSource _coinSound; 
        [SerializeField] 
        private int _score = 10;  
        private void OnTriggerEnter2D(Collider2D collision)     //Pelaajan kerätessä kolikon, kolikko tuhoutuu äänen kera, ja pelaaja saa _scoren verran pisteitä 
        { 
            if (collision.tag.Equals("Player")) 
            { 
                Instantiate(_coinSound, transform.position, Quaternion.identity);  
                Destroy(gameObject); 
                ScoreScript.scoreValue += _score; 
            } 
        } 
    } 
