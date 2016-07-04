# tennis-kata

Scenario: Start of match

Given 
* a 3-set game,
* played between Player 1 and Player 2,
* at the start of the game

When
* the game is about to start

Then
* the scoreboard should show:

```	
Player   | 1 | 2 | 3 | Game
---------------------------
Player 1 | 0 |   |   | 0
Player 2 | 0 |   |   | 0
```

_____________________________________________________

Scenario: First point

Given 
* a 3-set game,
* played between Player 1 and Player 2,
* in the first game of the match

When
* Player 1 scores a point

Then
* the scoreboard should show:
	
```
Player   | 1 | 2 | 3 | Game
---------------------------
Player 1 | 0 |   |   | 15
Player 2 | 0 |   |   | 0
```


Given
* a 3-set game,
* played between Player 1 and Player 2,
* where the first 2 sets were scored 7-5 and 6-4,
* and the 3rd set is currently 2-0,
* and the current game is currently 40-0

When
* Player 2 scores a point

Then
* the scoreboard should show:

```
Player   | 1 | 2 | 3 | Game
---------------------------
Player 1 | 7 | 4 | 2 | 40
Player 2 | 5 | 6 | 0 | 15
```

__________________________________________________

Scenario: Deuce

Given 
* a 3-set game,
* played between Player 1 and Player 2,
* in the first game of the match,
* where the current score is deuce

When
* Player 1 scores a point

Then
* the scoreboard should show:

```	
Player   | 1 | 2 | 3 | Game
---------------------------
Player 1 | 0 |   |   | A
Player 2 | 0 |   |   | 40
```

___________________________________________________

Scenario: Winning a game

Given 
* a 3-set game,
* played between Player 1 and Player 2,
* in the first game of the match,
* where the current score is 40-30

When
* Player 1 scores a point

Then
* the scoreboard should show:

```	
Player   | 1 | 2 | 3 | Game
---------------------------
Player 1 | 1 |   |   | 0
Player 2 | 0 |   |   | 0
```

___________________________________________________

Scenario: Winning a match

Given 
* a 3-set match,
* played between Player 1 and Player 2,
	
When
* Player 1 scores a point
Then
* the scoreboard should show:

```	
Player   | 1 | 2 | 3 | Game
---------------------------
Player 1*| 7 | 4 | 6 | 
Player 2 | 5 | 6 | 4 | 
```
