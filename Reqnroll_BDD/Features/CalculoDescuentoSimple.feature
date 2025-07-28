Feature: Calcular descuentos simples
  Para asegurar que los descuentos por grupo de cliente y de producto se apliquen correctamente
  Como sistema de facturacion
  Quiero calcular el total de la factura considerando los porcentajes de descuento de cliente y producto

  Scenario: Calcular descuento Cliente-Producto simple
    Given un grupo de cliente "Especialista" con porcentaje 8
    And un grupo de producto "Herramientas" con porcentaje 3
    And un cliente "Juan Perez" del grupo de cliente "Especialista"
    And un almacen "ALM001"
    And un producto "Taladro BOSCH" con codigo "P001" del grupo "Herramientas" con precio venta 990 y precio costo 800 en el almacen "ALM001"
    And una condicion de pago "Contado" con dias 1
    And un metodo de pago "Tarjeta"
    When creo una factura con cantidad 1 del producto "P001"
    Then el porcentaje de descuento total debe ser 11
    And el precio unitario debe ser 990
    And el total de la factura debe ser 881.10
