Feature: Registro de cliente con validaciones
  Como usuario
  Quiero registrar un nuevo cliente
  Para asegurar que los campos se validen correctamente antes de guardar

  Scenario: Validacion de correo incorrecto y luego correcto
    Given el usuario abre la pagina de registro de cliente
    When ingresa "C001" en el campo Codigo Cliente
    And ingresa "Carlos Mendoza" en el campo Nombre
    And selecciona "CI" en el campo Tipo Documento
    And ingresa "6543210" en el campo Numero de Documento
    And ingresa un email invalido "carlos@@mail" en el campo Email
    And selecciona "Especialista" en el campo Grupo Cliente
    And hace clic en el boton de registrar

    When corrige el campo Email con "carlos@mail.com"
    And hace clic en el boton de registrar otra vez
    Then debe mostrarse un mensaje de exito
