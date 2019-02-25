## Joc in unity ce trebuie sa contina:

- Meniu
  - [x] selectie de nivel de dificultate/joc
  - [x] start game
  - [x] exit game

- Harta
  - [x] se deruleaza la nesfarsit
  - [x] se genereaza obstacole si/sau diferente de nivel
    
- GUI
  - [x] Player Health
  - [x] Abilitati/Cooldown
  - [x] Minimap
  - [] Inventar/Echipament
  - [x] afisare punctaj
    
Player
// controlat de la tastatura si mouse
// mouse: FIRE si directie
// keyboard: miscare, jump
// poate trage cu proiectile
// are abilitati speciale accesate prin apasarea unui buton in interfata grafica
// pentru incarcarea abilitatilor playerul trebuie sa stranga puncte/drop-uri
// este animat (la miscare, fire, jump etc.)
// daca un proiectil il atinge ii scade din viata/vieti
// daca omoara inamici sau ia drop-uri creste punctajul
// poate ataca de aproape sau de la distanta
poate cumpara echipament
poate strange de pe harta echipament
isi poate echipa/modifica/actualiza echipamentul
are efecte vizuale si sonore atunci cand merge, ataca sau foloseste o abilitate

Inamici
Jucator online in multiplayer
Serverul trebuie sa accepte cel putin 5 jucatori simultan
// Are afisat health bar

nonpvp
// se genereaza/instantiaza automat in scena/pe harta
// lanseaza proiectile catre utilizator atunci cand este in proximitate
// pot fi statici sau dinamici (nu trebuie sa se deplaseze neaparat spre utilizator, dar trebuie sa aiba o miscare/animatie)
// in functie de nivelul de dificultate, trag mai repede sau mai incet si se spawneaza mai multi sau mai putini
// au atasata o bara de viata care scade atunci cand sunt atinsi de proiectilele player-ului
// atunci cand mor, explodeaza (animatie)
