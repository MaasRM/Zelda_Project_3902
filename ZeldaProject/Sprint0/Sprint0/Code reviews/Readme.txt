************************************************************************************************************
											Team 3 Readme file
************************************************************************************************************

Jacob Kline, Jared Zins, Phil Brocker, Riley Maas, Nathan Schultz

Jacob Kline: Review LinkSpriteFactory.cs for readability, Review GelStateMachine.cs for maintainability
Riley Maas: Review LinkStateMachine.cs for readability, Review BowItem.cs for maintainability
Jared Zins: Review FairyItem.cs for readability, Review Link.cs for maintainability
Phil Brocker: Review Stalfos.cs for readability, Review Block.cs for maintainability
Nathan Schultz: Review Block.cs for readability, Review RectangleLinkMoveRightAttack.cs for maintainability

************************************************************************************************************
											Program Controls
************************************************************************************************************
Move Link: W(Up), A(Left), S(Down), D(Right)
Damage Link: E
Link Items: 1(Green Arrow), 2(Blue Arrow), 3(Normal Boomerang), 4(Blue Boomerang), 5(Bomb), 6(Fireball)
Attack: Z, N
Changing Block: T(Previous), Y(Next)
Enemies: O(Previous), P(Next)
Items: U(Previous), I(Next)
Quit: Q
Restart: R

************************************************************************************************************
										Notes on Functionality
************************************************************************************************************

Wallmaster enemy only appears when Link is nearby, so its location for testing purposes was hardcoded at
(400, 400) or in the middle of the screen towrads the bottom.

************************************************************************************************************
											Known Bugs
************************************************************************************************************
Enemies Wander Off The Screen: No edge detection present
Link Can Move Off The Screen: No edge detection present
Switching Between Items And Blocks Has No Delay, Potentially Skipping Over An Item or Block: Add in a delay for input reads

************************************************************************************************************
											Other Tools
************************************************************************************************************
Used github respository and GitHub Extention For Visual Studio

************************************************************************************************************
											Code Analysis
************************************************************************************************************
0 Errors and 0 Warnings Present
