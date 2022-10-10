# HoLGame

## Create Game

###### /api/Game/CreateGame

To create a Game you need to send a request to /api/Game/CreateGame specifying the name of the name and the number of players. The number of players define in this method will impact since it will be the number of different players to register in the game.

This operation will return a game identifier that needs to be used in order to be able to have multiple games happening at the same time.

## Create Players

###### /api/Player/CreatePlayer

To register a player is only necessary to specify the name of the player, due to time constrictions there is no validation of duplicate names and the api will not function correctly if the same name is introduced twice.

## Join Game

###### /api/Play/JoinGame

This method represents the intention of a previous registered players to participate in a game, the game can only start after all the players, according to the number defined in the ***CreateGame*** method have registered.

## Start Game

###### /api/Play/StartGame

This operation will initialize the game, validating that all players are registered and will return the first card.

## Play Game

###### /api/Play/PlayGame

This method allows players to participate in the game by defining their play choice, the player name and the game identifier.

## Game Score

###### /api/Play/GameScore

This options can be called at any point in game and provides the current result of the game. When the game ends the final result will be showned with the correct answers of all players.

