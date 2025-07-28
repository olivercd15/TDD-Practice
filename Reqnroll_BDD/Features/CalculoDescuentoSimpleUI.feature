Feature: Calculo visual de descuentos en UI

  Scenario: Calcular descuento combinado desde la vista
    Given el usuario abre la pagina de registro de factura
    When selecciona el cliente "Juan Perez"
    And selecciona el producto "Taladro Bosh"
    And el usuario ingresa cantidad 1
    Then el precio unitario UI debe ser 990
    And el total del producto UI debe ser 881.10
    And el total de la factura UI debe ser 881.10
