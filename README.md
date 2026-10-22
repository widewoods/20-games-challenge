# 20 Games Challenge

My attempt at the [20 Games Challenge](https://20_games_challenge.gitlab.io/): making 20 small games, one at a time, and keeping every project in this repo.

**Progress: 1 / 20**

## Games

| #  | Game | Engine | Playable | Started | Finished |
|----|------|--------|----------|---------|----------|
| 01 | [Pong](01-pong) | Unity | [itch.io](https://widewoods.itch.io/20-games-challenge01-pong) | 2026-10-19 | 2026-10-22 |
| 02 |  |  |  |  |  |
| 03 |  |  |  |  |  |
| 04 |  |  |  |  |  |
| 05 |  |  |  |  |  |
| 06 |  |  |  |  |  |
| 07 |  |  |  |  |  |
| 08 |  |  |  |  |  |
| 09 |  |  |  |  |  |
| 10 |  |  |  |  |  |
| 11 |  |  |  |  |  |
| 12 |  |  |  |  |  |
| 13 |  |  |  |  |  |
| 14 |  |  |  |  |  |
| 15 |  |  |  |  |  |
| 16 |  |  |  |  |  |
| 17 |  |  |  |  |  |
| 18 |  |  |  |  |  |
| 19 |  |  |  |  |  |
| 20 |  |  |  |  |  |

## Repo Structure

Each game is a self-contained engine project in its own numbered folder, with its own `.gitignore`.

```
20-games-challenge/
├── README.md
├── .gitignore        # OS/editor junk only
├── 01-name/
│   ├── .gitignore    # engine-specific
│   └── ...
└── 02-name/
```

## Running a Game

1. Open the game's folder (e.g. `01-name/`) as a project in its engine.
2. Press Play, or grab a build from the **Playable** link above.

## Notes

- Commit messages are prefixed with the game, e.g. `pong: add scoring`.
- Builds are not committed; they live on itch.io or GitHub Releases.