# DRUM HERO

## Description

Un projet de realité virtuel destiné à l'occulus quest 2
L'intêret etait de pouvoir pratiquer la batterie en réalité virtuel soit seul soit avec un morceau de musique en fond qui indiquerait quoi jouer (comme dans un guitar hero)

## Ce qui fonctionne

On peut jouer de la batterie assez simplement
la mise en place de la VR pour le casque ainsi que le build a été assez facile (necessite quelques plugins pour unity ainsi que de pouvoir build pour android.)
les fonctionnalités de base de la VR (controller, placement de la camera etaient assez simple aussi les plugins sont bien fait)

## Les soucis

Un problème physique. Ne pas avoir de rebond quand on tape une cymbale ou un tome, est très genant, impossible de jouer comme il faut.

### Implémentation du mode avec une musique

on a pensé a plusieurs façon de le faire. 

 - avec des fichiers midi :
    1- jouer un morceau et recuperer les evenements de la batterie pour les afficher en temps reel avec une animation.
    probleme : pas possible d'anticiper les coups.
    2- Obtenir tout les evenements à l'avance et les jouer sur une timeline en parallèle avec le morceau pour avoir les coups en avance.
    3- créer un editeur de piste pour pouvoir manuellement créer des pistes jouable. (necessitait de créer une deuxieme applications).
    certainement la meilleur solution mais impossible a réalisé par manque de temps.
    on s'est rendu compte trop tard que la solution 1 etait pas terrible.
