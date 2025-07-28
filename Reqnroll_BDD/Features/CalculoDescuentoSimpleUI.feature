Feature: Calculo de descuentos desde la interfaz

  Scenario: Calcular correctamente el total con descuentos combinados
    Given el usuario abre la pagina de registro de factura
    When selecciona el cliente "Juan Perez"
    And selecciona el producto "Taladro BOSCH"
    And el sistema muestra el precio venta de "990"
    And el grupo cliente tiene un descuento de 8
    And el grupo producto tiene un descuento de 3
    And el usuario ingresa cantidad 1
    And hace clic en el boton "Calcular"
    Then el sistema debe mostrar un total de "881.10"
