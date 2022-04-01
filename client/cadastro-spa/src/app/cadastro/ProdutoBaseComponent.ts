import { ElementRef } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FormBaseComponent } from '../base-components/FormBaseComponent';
import { Pessoa } from './models/pessoa';

export abstract class CadastroBaseComponent extends FormBaseComponent {
  pessoa!: Pessoa;
  errors: any[] = [];
  cadastroForm!: FormGroup;

  constructor() {
    super();

    this.validationMessages = {
      nome: {
        required: 'Informe o Nome',
        minlength: 'Mínimo de 3 caracteres',
        maxlength: 'Máximo de 300 caracteres',
      },
      cpf: {
        required: 'Informe o CPF',
        minlength: 'Mínimo de 11 caracteres',
        maxlength: 'Máximo de 11 caracteres',
      },
      idade: {
        required: 'Informe a idade',
      },
      nomeCidade: {
        required: 'Informe a cidade',
        minlength: 'Mínimo de 3 caracteres',
        maxlength: 'Máximo de 200 caracteres',
      },
      uf: {
        required: 'Informe o estado',
        minlength: 'Mínimo de 2 caracteres',
        maxlength: 'Máximo de 2 caracteres',
      },
    };

    super.configurarMensagensValidacaoBase(this.validationMessages);
  }

  protected configurarValidacaoFormulario(formInputElements: ElementRef[]) {
    super.configurarValidacaoFormularioBase(
      formInputElements,
      this.cadastroForm
    );
  }
}
