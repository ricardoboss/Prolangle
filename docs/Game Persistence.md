# Game Persistence

This is how games are tracked in your local browser.

## Data structures

These are the basic data structures and their properties.

_Game_

* Game ID (random UUID)
* Played At (Timestamp)
* Solution (UUID of _Language_)
* Type (UUID of _Game Type_)

_Game Type_

(Game Type UUIDs are hardcoded in Prolangle.dll)

_Guess_

* Game ID (foreign key for _Game_)
* Guessed At (Timestamp)
* Language (UUID of _Language_)

_Language_

(Language UUIDs are hardcoded in Prolangle.dll)

---

This structure allows the following scenarios:

- Determine order of guesses per game
- Determine win rate per game
- Average guesses per game
- Allows changing algorithm for target language without affecting previously played games
- Allows adding more game types with similar guessing semantics in the future

## Storage

We leverage IndexedDB to store games.
Although it does not work for web workers (see https://caniuse.com/indexeddb), it provides all the functionality we
need while playing.
