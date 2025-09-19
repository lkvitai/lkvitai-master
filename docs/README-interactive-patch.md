# Interactive Diagrams Patch

What this patch does:
- Enables Mermaid links (`securityLevel: "loose"`) via `docs/js/mermaid-init.js`.
- Adds clickable drill‑down:
  - Context → Container (`container/#portal-blazor`)
  - Context → Component (`component/#core-api`)
  - Container (API) → Component (`component/#core-api`)
- Adds stable anchors `{#portal-blazor}` and `{#core-api}` on target pages.

How to apply:
1) Extract the archive **to your repository root** (where `mkdocs.yml` is), so files land under `docs/...`.
2) Restart the dev server:
   ```powershell
   .\.venv\Scripts\mkdocs serve
   ```
3) Open **Architecture → C4 Context** and click the nodes.
