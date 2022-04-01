import { Component, OnInit } from '@angular/core';
import { Pessoa } from '../models/pessoa';
import { CadastroService } from '../services/cadastro.service';

@Component({
  selector: 'app-listar',
  templateUrl: './listar.component.html',
  styleUrls: ['./listar.component.css'],
})
export class ListarComponent implements OnInit {
  public pessoas?: Pessoa[];

  constructor(private cadastroService: CadastroService) {}

  ngOnInit(): void {
    this.cadastroService
      .obterTodos()
      .subscribe((pessoas) => (this.pessoas = pessoas));
  }
}
