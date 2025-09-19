# ADR-0001: Record architecture decisions

*Status:* Accepted  
*Date:* 2025-09-19

## Context
We need a lightweight, Git-centered documentation stack with diagrams.

## Decision
Use **MkDocs Material** (GitHub Pages), **Mermaid** for quick diagrams, and **PlantUML (C4) via Kroki**. Store `.drawio` sources; embed SVG into pages.

## Consequences
- Pros: simple, fast, code-reviewed via PR; beautiful UI; diagrams as code.
- Cons: C4 requires Kroki/PlantUML; draw.io редактируется вне страницы.
