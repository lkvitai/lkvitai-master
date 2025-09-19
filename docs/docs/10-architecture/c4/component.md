# C4: Component (Core API)

```kroki-plantuml
@startuml
!include https://raw.githubusercontent.com/plantuml-stdlib/C4-PlantUML/master/C4_Component.puml
Container_Boundary(api,"Core API"){
  Component(orderSvc,"Order Service",".NET","Create/Update/KitImpact")
  Component(ruleSvc,"Rules Engine",".NET","Tech rules")
  Component(qcSvc,"QC Service",".NET","Quality checks")
}
Rel(orderSvc, ruleSvc, "evaluate")
@enduml
```

```kroki-plantuml
@startuml
Alice -> Bob: Hi
@enduml
```


```kroki {type=plantuml}
@startuml
Alice -> Bob: Hi
@enduml
```


```kroki-plantuml
@startuml
Alice -> Bob: Hi
@enduml
```

```kroki {type=plantuml}
@startuml
Alice -> Bob: Hi (via kroki fence)
@enduml
```

