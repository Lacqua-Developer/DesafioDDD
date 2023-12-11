import React, { useState } from 'react';
import { Container, Row, Col, InputGroup, FormControl, Card, Button } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';

interface Product {
  id: number;
  name: string;
  category: string;
  price: number;
}

const products: Product[] = [
  { id: 1, name: 'Produto 1', category: 'Categoria A', price: 20 },
  { id: 2, name: 'Produto 2', category: 'Categoria B', price: 30 },
  // Adicione mais produtos conforme necessário
];

const App: React.FC = () => {
  const [searchQuery, setSearchQuery] = useState<string>('');
  const [selectedProduct, setSelectedProduct] = useState<Product | null>(null);
  const [cartCount, setCartCount] = useState<number>(0);

  const filterProducts = (query: string) => {
    setSearchQuery(query);
  };

  const addToCart = (productId: number) => {
    setCartCount(cartCount + 1);
    // Lógica para adicionar produto ao carrinho (pode ser armazenado em um array, por exemplo)
    // Aqui, apenas atualizamos a contagem no carrinho.
  };

  const renderProductList = () => {
    const filteredProducts = products.filter(
      (product) =>
        product.name.toLowerCase().includes(searchQuery.toLowerCase()) ||
        product.category.toLowerCase().includes(searchQuery.toLowerCase())
    );

    return filteredProducts.map((product) => (
      <Card key={product.id} className="mb-4" onClick={() => setSelectedProduct(product)}>
        <Card.Body>
          <Card.Title>{product.name}</Card.Title>
          <Card.Subtitle className="mb-2 text-muted">{product.category}</Card.Subtitle>
          <Card.Text>Preço: ${product.price}</Card.Text>
          <Button onClick={() => addToCart(product.id)}>Adicionar ao Carrinho</Button>
        </Card.Body>
      </Card>
    ));
  };

  return (
    <Container className="mt-4">
      <Row>
        <Col md={8}>
          <InputGroup className="mb-3">
            <FormControl
              placeholder="Pesquisar por nome ou categoria"
              value={searchQuery}
              onChange={(e) => filterProducts(e.target.value)}
            />
          </InputGroup>
          <Row>{renderProductList()}</Row>
        </Col>
        <Col md={4}>
          {selectedProduct && (
            <Card>
              <Card.Body>
                <Card.Title>{selectedProduct.name}</Card.Title>
                <Card.Subtitle className="mb-2 text-muted">{selectedProduct.category}</Card.Subtitle>
                <Card.Text>Preço: ${selectedProduct.price}</Card.Text>
                <Button onClick={() => addToCart(selectedProduct.id)}>Adicionar ao Carrinho</Button>
              </Card.Body>
            </Card>
          )}
          <div className="mt-3">Carrinho: {cartCount} itens</div>
        </Col>
      </Row>
    </Container>
  );
};

export default App;
