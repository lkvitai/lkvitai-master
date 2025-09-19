namespace Lkvitai.Mes.Contracts;
public record PrintLabelRequest(string Template, string PayloadJson);
public record OrderCreated(string OrderId, string ProductType, decimal Width, decimal Height);
