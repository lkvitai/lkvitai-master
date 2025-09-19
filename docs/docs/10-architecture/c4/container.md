# C4: Container

```kroki-plantuml
@startuml
!include https://raw.githubusercontent.com/plantuml-stdlib/C4-PlantUML/master/C4_Container.puml
Person(user, "Operator")
System_Boundary(lk,"LKvitai.MES"){
  Container(web,"Portal (Blazor)","ASP.NET","UI + dashboards")
  Container(api,"Core API",".NET","Business services")
  ContainerDb(db,"SQL","MS SQL","Operational DB")
  Container(mqtt,"Broker","MQTT","Events")
}
Rel(user, web, "uses")
Rel(web, api, "REST")
Rel(api, db, "CRUD")
Rel(api, mqtt, "Pub/Sub")
@enduml
```

