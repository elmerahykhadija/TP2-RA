# Rapport de TP : Système de Vision Augmentée et Identification IA

![Status](https://img.shields.io/badge/status-completed-success) ![Unity](https://img.shields.io/badge/Unity-6-blue) ![Vuforia](https://img.shields.io/badge/Vuforia-11.4.4-orange)

## Table des matières
- [Introduction et objectifs](#introduction-et-objectifs)
- [Auteurs](#auteurs)
- [Configuration de l'environnement](#configuration-de-lenvironnement)
- [Mise en œuvre technique](#mise-en-œuvre-technique)
- [Déploiement mobile](#déploiement-mobile)
- [Résultats et validation](#résultats-et-validation)
- [Conclusion](#conclusion)

## Auteurs

| Nom |
|-----|
| Khadija El Merahy |
| Ghizlane Aitelhaj |

## Introduction et objectifs

Ce projet porte sur la conception d'une application de réalité augmentée intelligente développée sous Unity 6. L'objectif est de transformer un flux vidéo brut capturé par une caméra en une interface d'analyse en temps réel.

L'objectif principal consiste à détecter une cible physique et à superposer des métadonnées extraites par une simulation d'IA. Le projet démontre aussi le scripting C#, l'intégration du SDK Vuforia, la gestion du cycle de vie d'une application mobile et l'optimisation d'une interface spatiale.

### Fonctionnalités principales
- Détection d'une image cible en temps réel via Vuforia
- Suivi dynamique de la cible avec rendu 3D superposé
- Simulation d'une analyse IA avec score de confiance
- Interface utilisateur en World Space pour les retours visuels
- Gestion des états de détection, d'analyse et de perte de cible


## Configuration de l'environnement

L'environnement de développement a été configuré pour supporter un déploiement multiplateforme Windows et Android.

| Composant | Spécification |
|-----------|---------------|
| Moteur de rendu | Unity 6 (6000.x) |
| SDK de vision | Vuforia Engine 11.4.4 |
| Langage | C# |
| Plateforme de test | Windows PC |
| Caméra | Webcam système |
| Cible | target_astronaut_USLetter, 7 cm x 12 cm |

### Phase d'installation

Le package Vuforia a été intégré pour activer les fonctionnalités de reconnaissance d'image. La configuration inclut l'activation de la licence développeur et le paramétrage de l'ARCamera.

![Installation Vuforia](img/image.png)

![Licence Vuforia](img/image-2.png)

## Mise en œuvre technique

### Configuration de la scène

La caméra Unity standard a été remplacée par une ARCamera fournie par Vuforia. Cette configuration assure la calibration caméra, l'estimation de pose et l'affichage du contenu augmenté.

![ARCamera Configuration](img/image-1.png)

Une Image Target a ensuite été créée et liée à la base de données Vuforia `VuforiaMars_Images`.

![Image Target Setup](img/image-3.png)

L'asset `target_astronaut_USLetter` sert d'ancrage spatial. Une capsule 3D est liée hiérarchiquement à la cible pour un tracking précis.

Une interface IA est affichée avec un cadre vert de sélection et un texte dynamique en World Space afin de suivre les mouvements de l'image.

![Capsule 3D Rendering](img/image-5.png)

### Logique IA

Un script C# personnalisé, `AIObjectDetector.cs`, gère la transition entre la détection brute et l'affichage intelligent.

![Script IA Architecture](img/image-6.png)

#### Cycle de détection

```text
Image capturée
   -> Matching Vuforia
   -> Cible trouvée ou non trouvée
   -> OnTargetDetected()
   -> Activation du cadre de sélection
   -> Routine d'analyse simulée
   -> Mise à jour du score et du texte
```

#### Comportement du script

| État | Événement | Action |
|------|-----------|--------|
| Détection | Cible trouvée | Affichage du cadre vert et lancement de l'analyse |
| Analyse | Délai de 1.5 s | Mise à jour du texte avec un score de confiance de 98 % |
| Perte | Cible perdue | Réinitialisation de l'interface et affichage de NOT_OBSERVED |

## Déploiement mobile

Même si le prototype a été validé principalement via webcam, la chaîne de compilation Android a été préparée.

### Étapes de déploiement

- Switch Platform de Windows vers Android dans les Build Profiles
- Configuration de l'OpenJDK et de l'Android SDK via Unity Hub
- Activation du backend de scripting IL2CPP
- Ciblage de l'architecture ARM64
- Configuration des autorisations d'accès à la caméra
- Génération de l'APK `TP_AR_IA.apk`

## Résultats et validation

Le système a été validé par des tests en temps réel.

### Tests de fonctionnement

| Test | Résultat |
|------|----------|
| Tracking stable | La console confirme l'état `TRACKED--NORMAL` lors de l'identification |
| Réactivité | Réinitialisation instantanée du système lors de la perte du signal (`NOT_OBSERVED`) |
| Rendu 3D | La capsule et l'interface restent synchronisées avec la cible |
| Analyse IA | Le score et le message s'affichent après la routine simulée |

### Observations

- Latence de détection faible
- Comportement stable après plusieurs cycles de détection
- Interface réactive lors de la perte et du retour de la cible

## Conclusion

Ce TP démontre la capacité à fusionner la vision par ordinateur et le développement applicatif. La maîtrise des outils de build APK et du scripting C# permet de projeter cette application vers des cas d'usage industriels comme la maintenance assistée ou l'analyse de données sur le terrain.

Le projet confirme également la pertinence d'une architecture AR basée sur Vuforia pour créer une expérience d'identification intelligente, stable et extensible.
