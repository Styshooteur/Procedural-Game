# SPIDRUN

Ce projet a été réalisé par André Silva de Carvalho et Victor Gonnet dans le cadre du module GPR4400. Le travail consistait a créer un jeu contenant de la génération procédurale ainsi que des IA (ennemis) avec du Pathfinding et éventuellement du Steering Behaviour.

### Introduction

Dans l'idée de base, nous souhaitions incarner une arraignée. Le but étant pour cette arraignée de trouver la sortie de sa grotte. Pour ce faire, nous voulions créer une grotte générée procéduralement en Cellular Automata (parce que c'est ce qui ressemble le plus a une grotte), composée de un ou plusieurs niveaux (étages), avec différents ennemis qui spawn de manière procédurale. Si possible, on aurait aimé faire spawn l'arraignée en bas de la map et faire spawn une sortie en haut de la map pour chaque étage.

### Les problèmes rencontrés

Un des principaux soucis de la génération procédurale est qu'il faut faire spawn toutes les prefabs via le script du Cellular Automata. Par conséquent, ce sont des clones que nous faisons spawn et donc il est plus dur de donner des reférences. Par exemple lorsqu'il s'agit de donner le player en reférence aux ennemis pour qu'il se fasse chase. Il faut passer par les publics properties pour pouvoir avoir le transform de chacune des entités.

![code3](https://user-images.githubusercontent.com/71374090/121260741-05161800-c8b2-11eb-90e5-39a32e96880e.PNG)

Le second problème est étroitement lié au premier, il s'agit de faire spawn intelligement les prefabs notamment les ennemis, le player et le portail de fin. Pour cela, nous avons crée une fonction StartRoom qui se charge d'instancier correctement les prefabs. Pour chaque prefabs on choisi une région aléatoirement, puis dans cette région on choisi une tile aléatoirement, puis on instancie la prefab dessus. Pour ce qui est des ennemis, on régule la difficulté en faisant spawn les ennemis en fonction du nombre de tile par région. De ce fait, plus la région est grande plus le nombre et la difficulté des ennemis augmentent.

![Code2](https://user-images.githubusercontent.com/71374090/121261367-f1b77c80-c8b2-11eb-95b8-c343ce080f5c.PNG)
![Code1](https://user-images.githubusercontent.com/71374090/121261395-fa0fb780-c8b2-11eb-86ec-cfec2abbaa19.PNG)

Un autre problème nous a beaucoup occupé en ce qui concerne les IA. Puisque nous utilisons un circle collider en trigger pour pouvoir détecter le player, nous ne pouvons pas utiliser OnTriggerEnter pour infliger les dégats, il a donc fallu utiliser OnCollisionEnter ce qui rend les combats plus approximatifs. Comme nous utilisons des collisions physiques pour les combats, notre player subissait fréquemment des forces additionnels néfastes entravant ses déplacements. Pour régler cela nous avons dû ajouter une ligne de code dans le script du player.

![code4](https://user-images.githubusercontent.com/71374090/121261316-dfd5d980-c8b2-11eb-95ed-aaaec70704e8.PNG)

Enfin, le plus gros problème repose dans le pathfinding. Nous n'avons pas réussi a l'implémenter donc on a du simplifier drastiquement le comportement de nos IA et réduire leurs box collider pour qu'elles puissent plus facilement arriver jusqu'au player.

### Les implémentations réussies

- Une grotte intégralement générée en Cellular Automata. L'expérience dans cette grotte n'est donc jamais la même.
- Le player et ses déplacements grâce à la position du curseur ainsi que ZQSD pour une plus grande magnabilité.
- La toile, le player peut tisser une toile derrière lui qui inflige des dégats aux ennemis.

![Spidrun Screenshot 2021 06 08 - 23 01 12 05](https://user-images.githubusercontent.com/71374090/121261438-098f0080-c8b3-11eb-847d-4fca41d5fb57.png)

- Le premier ennemi, la chouette lorsqu'elle détecte le joueur lui dash dessus après quelques secondes d'incantation.
- Le deuxième ennemi, la chauve-souris chase le joueur lorsqu'elle le détecte.

![Spidrun Screenshot 2021 06 08 - 23 01 45 89](https://user-images.githubusercontent.com/71374090/121261472-13b0ff00-c8b3-11eb-9af6-a57ab32361aa.png)

- Le portail de fin, permet de finir le jeu quand le joueur s'en approche.

![Spidrun Screenshot 2021 06 08 - 23 02 26 58](https://user-images.githubusercontent.com/71374090/121261508-1f042a80-c8b3-11eb-8982-641a892d53e1.png)

- Un GameMenu et un PauseMenu fonctionnels.

![Spidrun Screenshot 2021 06 08 - 23 04 06 15](https://user-images.githubusercontent.com/71374090/121261549-29bebf80-c8b3-11eb-99b3-129292b26fbe.png)

### Conclusion

En conclusion, ce projet était beaucoup plus compliqué que les précédents en terme de programmation pure. Il a fallu apprendre de nouvelles méthodes ainsi que découvrir ce qu'est la génération procédural et l'IA. Nous avons fait de notre mieux avec les capacités dont nous disposions, mais nous avons surtout appris énormément de choses. Cela a été très instructif d'essayer de résoudre les problèmes ainsi que de tenter la création d'une IA de A à Z.
