# Game Design Document: DiceUP

## Game Overview

**Title:** DiceUP  
**Genre:** Slot Game / Single-Player Simulation  
**Platform:** Online / Mobile

**Description:**  
DiceUP is an engaging slot game where players roll a virtual d20 to determine their fate in a world where health is
currency. Players aim to accumulate 10,000 gold coins while avoiding bankruptcy, which leads to death.

## Key Features & Mechanics

### Core Loop

1. **Roll the Dice:** Players press a single button to roll a virtual d20.
2. **Determine Outcome:** The outcome combines the d20 value with a hidden score based on four d6 dice.
3. **Manage Health:** Players track their health as currency, aiming to reach 10,000 coins before running out.

### Health as Currency

- **Health Points (HP):** Players start with 1,000 HP.
- **Gains/Losses Table:** Outcomes based on the d20 roll and the sum of four d6 calculations:
    - **Critical Failure (1):** Lose 20% of the current HP.
    - **Failure (2-5):** Lose HP based on the formula: `HP Loss = 10 * (4d6 Roll - 2)^2 / 400`.
    - **Success (6-15):** Gain HP based on the formula: `HP Gain = 10 * (4d6 Roll - 2)^2 / 400`.
    - **Critical Success (16-20):** Gain 20% of the difference between 10,000 HP and the current HP.

### Ad Multiplier

- Players can opt to watch an ad that gives a **__Multiplier Buff__** that lasts 5 minutes:
    - **__Multiplier Buff__** For the next 10 rolls, all health gains are doubled.

### Victory and Defeat Conditions

- **Victory:** Reach 10,000 HP (gold coins).
- **Defeat:** Health drops to 0 HP, resulting in a "Game Over" screen.

### Special Features

- **Cubes for Properties:** Visual representation of gains/losses using 3D cubes.
- **AI-Generated Audio:** Background music and sound effects enhance the experience.

## Progression Systems

- **Primary Goal:** Accumulate 10,000 gold coins while managing health.
- **End Condition:** The game ends when the player reaches 10,000 HP or runs out of health.

## Monetization Strategy

- **Dice Skins:** Players can purchase different skins for their dice, enhancing the visual experience.
- **Ad-Free Version:** Players can buy an ad-free version that grants a permanent HP gain (e.g., +50 HP) for each game
  session.
- **Ad Integration:** In the free version, players see an ad after every 15 turns.

## Art and Sound

- **Visual Style:** Minimalist design featuring colorful 3D cubes for property gains/losses.
- **Sound Design:** Engaging AI-generated audio for music and sound effects.

## User Interface

- **Main Screen:** Displays the d20 roll button, current health (HP), and property cubes.
- **Game Feedback:** Visual and audio cues for gains, losses, and game over conditions.

## Identify Challenges

### Potential Problems

1. **Balancing Health Gains and Losses:**

- **Issue:** Ensuring the game is neither too easy nor too difficult.
- **Solution:** Playtesting and adjusting the gains/losses table based on player feedback.

2. **Ad Integration:**

- **Issue:** Ads may disrupt the gameplay experience, will need to balance ad revenue with player satisfaction.
- **Solution:** Offer an ad-free version and ensure ads are optional with benefits, such as the **__Multiplier Buff__**.

3. **Player Engagement:**

- **Issue:** Keeping players engaged over time.
- **Solution:** Introduce new dice skins and periodic updates with new features.

- **Issue:** Ensuring the game has more content to keep players engaged.
- **Solution:** Implement a leaderboard system to encourage competition among players, with rewards for top scorers and
  some basic pvps or guilds.

4. **Technical Performance:**

- **Issue:** Ensuring the game runs smoothly on WebGL and ships to Itch.io.
- **Solution:** Optimize the game for performance and test builds on major merges and in different browsers.

## Conclusion

DiceUP offers a unique twist on classic slot gameplay by integrating health as currency. Players navigate the risks of
rolling the dice to avoid bankruptcy while striving to accumulate wealth. This one-day project promises an exciting and
engaging experience!