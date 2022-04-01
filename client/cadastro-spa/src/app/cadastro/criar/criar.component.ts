import { Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControlName, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CadastroBaseComponent } from '../ProdutoBaseComponent';
import { CadastroService } from '../services/cadastro.service';

@Component({
  selector: 'app-criar',
  templateUrl: './criar.component.html',
  styleUrls: ['./criar.component.css'],
})
export class CriarComponent extends CadastroBaseComponent implements OnInit {
  @ViewChildren(FormControlName, { read: ElementRef })
  formInputElements!: ElementRef[];

  constructor(
    private fb: FormBuilder,
    private cadastroService: CadastroService,
    private router: Router,
    private toastr: ToastrService
  ) {
    super();
  }

  ngOnInit(): void {
    this.cadastroForm = this.fb.group({
      nome: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(300),
        ],
      ],
      cpf: [
        '',
        [
          Validators.required,
          Validators.minLength(11),
          Validators.maxLength(11),
        ],
      ],
      idade: ['', [Validators.required]],
      nomeCidade: [
        '',
        [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(200),
        ],
      ],
      uf: [
        '',
        [Validators.required, Validators.minLength(2), Validators.maxLength(2)],
      ],
    });
  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormulario(this.formInputElements);
  }

  adicionarPessoa() {
    if (this.cadastroForm.dirty && this.cadastroForm.valid) {
      this.pessoa = Object.assign({}, this.pessoa, this.cadastroForm?.value);

      this.cadastroService.criarCadastro(this.pessoa!).subscribe(
        (sucesso) => {
          this.processarSucesso(sucesso);
        },
        (falha) => {
          this.processarFalha(falha);
        }
      );
    }
  }

  processarSucesso(response: any) {
    this.cadastroForm.reset();
    this.errors = [];

    let toast = this.toastr.success(
      'Pessoa cadastrada com sucesso!',
      'Sucesso!',
      {
        timeOut: 1100,
      }
    );
    if (toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/cadastro/listar-todos']);
      });
    }
  }

  processarFalha(fail: any) {
    this.errors = Object.values(fail.error.errors);
    this.toastr.error('Ocorreu um erro!', 'Opa :(');
  }
}
