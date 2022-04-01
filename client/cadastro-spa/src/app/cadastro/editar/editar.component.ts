import { Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import {
  FormBuilder,
  FormControlName,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Pessoa } from '../models/pessoa';
import { CadastroBaseComponent } from '../ProdutoBaseComponent';
import { CadastroService } from '../services/cadastro.service';

@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html',
  styleUrls: ['./editar.component.css'],
})
export class EditarComponent extends CadastroBaseComponent implements OnInit {
  @ViewChildren(FormControlName, { read: ElementRef })
  formInputElements!: ElementRef[];

  constructor(
    private fb: FormBuilder,
    private cadastroService: CadastroService,
    private router: Router,
    private route: ActivatedRoute,
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

    this.route.params.subscribe((params) => {
      this.cadastroService
        .obterPorId(params['id'])
        .subscribe((pessoa) => this.preencherCadastroForm(pessoa));
    });
  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormulario(this.formInputElements);
  }

  preencherCadastroForm(pessoa: Pessoa) {
    this.pessoa = pessoa;

    this.cadastroForm.patchValue({
      id: this.pessoa?.id,
      nome: this.pessoa?.nome,
      cpf: this.pessoa?.cpf,
      idade: this.pessoa?.idade,
      cidadeId: this.pessoa?.cidadeId,
      nomeCidade: this.pessoa?.nomeCidade,
      uf: this.pessoa?.uf,
    });
  }

  editarPessoa() {
    if (this.cadastroForm.dirty && this.cadastroForm.valid) {
      this.pessoa = Object.assign({}, this.pessoa, this.cadastroForm?.value);

      this.cadastroService.atualizarCadastro(this.pessoa!).subscribe(
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
      'Cadastro editado com sucesso!',
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
