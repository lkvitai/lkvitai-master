# C4: Context (interactive)

## Mermaid (clickable)
```mermaid
graph TD
  Customer((Customer)) -->|Orders| WebApp[Portal (Blazor)]
  WebApp -->|API| Core[Core API]
  Core --> DB[(SQL)]
  Core --> MQTT[(MQTT Broker)]

  %% clickable drill-down (relative links within /10-architecture/c4/)
  click WebApp "container/#portal-blazor" "Open container view" _self
  click Core   "component/#core-api"      "Open component view" _self
```

## PlantUML (clickable via Kroki)
```kroki-plantuml
@startuml
!include https://raw.githubusercontent.com/plantuml-stdlib/C4-PlantUML/master/C4_Context.puml
Person(customer, "Customer")
System(system, "LKvitai.MES", "Shopfloor & Portal")
System_Ext(agnum, "Agnum", "Accounting")
System_Ext(avea, "Avea", "Warehouse")
Rel(customer, system, "places orders")
Rel(system, agnum, "exports invoices")
Rel(system, avea, "sync stock")

' clickable drill-down (relative links within /10-architecture/c4/)
url of system is [[container/#portal-blazor]]
@enduml
```
