import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CadastroService } from '../services/cadastro.service';

@Component({
  selector: 'app-excluir',
  templateUrl: './excluir.component.html',
  styleUrls: ['./excluir.component.css'],
})
export class ExcluirComponent implements OnInit {
  constructor(
    private cadastroService: CadastroService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.cadastroService
        .excluirCadastro(params['id'])
        .subscribe((sucesso) =>
          this.router.navigate(['/cadastro/listar-todos'])
        );
    });
  }
}
