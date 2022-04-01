FROM node:16.14.2 AS ng-builder
RUN mkdir -p /app
WORKDIR /app
COPY client/cadastro-spa/package.json /app
RUN npm install
COPY ./client/cadastro-spa /app
RUN $(npm bin)/ng build --prod

FROM nginx
COPY client/cadastro-spa/nginx.conf /etc/nginx/nginx.conf
COPY --from=ng-builder /app/dist/cadastro-spa /usr/share/nginx/html

EXPOSE 80