---
name: commit-message
description: "Generate a git commit message. Use when: writing a commit, creating commit message, what should my commit say, summarize changes for git, commit description."
argument-hint: "optional: describe what changed"
---

# Commit Message Generator

## When to Use
- User asks to write or suggest a commit message
- User asks what to put in a commit message
- User wants to summarize staged/recent changes for git

## Rules

1. **Prefix** — always start with one of:
   - `feat:` — new feature (triggers minor version bump)
   - `fix:` — bug fix (triggers patch version bump)
   - `docs:` — documentation only
   - `chore:` — tooling, config, deps (no version bump)
   - `refactor:` — code change that is neither fix nor feat
   - `style:` — formatting, whitespace only
   - `test:` — adding or updating tests
   - Append `!` after the type for breaking changes: `feat!:` (triggers major bump)

2. **Message body** — one short imperative sentence (≤72 chars total). No period at the end.

3. **Emoji** — always append a relevant emoji at the end of the message.

4. **No fluff** — no "this commit", "I", or filler words.

## Procedure

1. Run `git diff --staged` (or `git diff HEAD` if nothing is staged) to inspect changes.
2. Identify the dominant change type (feat / fix / etc.).
3. Write a single-line message: `<type>: <short imperative description> <emoji>`
4. If multiple logical changes exist, pick the most significant one and note the others in a brief body (blank line after subject).

## Examples

```
feat: add dark mode toggle 🌙
fix: resolve null ref on empty blog post list 🐛
docs: update README with setup instructions 📝
chore: bump EF Core to 10.0.8 🔧
refactor: extract BlogPost validation to service 🛠️
feat!: rename BlogPost.Author to BlogPost.AuthorName 💥
```
